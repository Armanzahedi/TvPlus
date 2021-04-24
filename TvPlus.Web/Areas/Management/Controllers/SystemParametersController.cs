using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Services;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize("Permission")]
    public class SystemParametersController : Controller
    {
        private readonly ISystemParameterService _systemParameterService;
        public SystemParametersController(ISystemParameterService systemParameterService)
        {
            _systemParameterService = systemParameterService;
        }
        public IActionResult Index(bool root = false)
        {
            ViewBag.Root = root;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public string LoadGrid()
        {
            var form = Request.Form;
            var parser = new Parser<SystemParameter>(Request.Form, (IQueryable<SystemParameter>)_systemParameterService.GetDefaultQuery());
            return JsonConvert.SerializeObject(parser.Parse());
        }

        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(SystemParameter model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            _systemParameterService.AddOrUpdate(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return PartialView(_systemParameterService.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(SystemParameter model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            _systemParameterService.AddOrUpdate(model);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            return PartialView(_systemParameterService.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _systemParameterService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
