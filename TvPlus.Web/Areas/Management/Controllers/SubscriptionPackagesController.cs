using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;
using TvPlus.Web.Areas.Management.ViewModels;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class SubscriptionPackagesController : Controller
    {
        private readonly ISubscriptionPackageService _subscriptionPackageService;

        public SubscriptionPackagesController(ISubscriptionPackageService subscriptionPackageService)
        {
            _subscriptionPackageService = subscriptionPackageService;
        }
        [Authorize("Permission")]
        public IActionResult Index(bool root = false)
        {
            ViewBag.Root = root;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public string LoadGrid()
        {
            var model = _subscriptionPackageService.GetDefaultQuery().Select(m=>new SubscriptionPackageGrid(m)).AsQueryable();

            var parser = new Parser<SubscriptionPackageGrid>(Request.Form, model);
            return JsonConvert.SerializeObject(parser.Parse());
        }
        [Authorize("Permission")]
        public IActionResult Create()
        {
            return PartialView();
        }

        [Authorize("Permission")]
        public IActionResult Edit(int id)
        {
            return PartialView(_subscriptionPackageService.GetById(id));
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Save(SubscriptionPackage model)
        {
            if (!ModelState.IsValid)
                return PartialView("Edit", model);
            if (model.DiscountType == null || model.DiscountType == 0)
                model.Discount = 0;

            var savedCategory = _subscriptionPackageService.AddOrUpdate(model);

            return RedirectToAction("Index");
        }

        [Authorize("Permission")]
        public ActionResult Delete(int id)
        {
            return PartialView(_subscriptionPackageService.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _subscriptionPackageService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
