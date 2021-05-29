using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.ExtensionMethods;
using TvPlus.Infrastructure.Services;
using TvPlus.Web.Areas.Management.ViewModels;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class DiscountsController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IUserService _userService;
        public DiscountsController(IDiscountService discountService, IUserService userService)
        {
            _discountService = discountService;
            _userService = userService;
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
            var model = _discountService.GetDefaultQuery().Select(m => new DiscountGridViewModel(m)).AsQueryable();

            var parser = new Parser<DiscountGridViewModel>(Request.Form, model);
            return JsonConvert.SerializeObject(parser.Parse());
        }
        [Authorize("Permission")]
        public async Task<IActionResult> Create()
        {
            ViewData["Users"] = await _userService.GetDefaultQuery()
                .Select(u => new SelectListItem() { Value = u.Id, Text = $"{u.FirstName} {u.LastName}"}).ToListAsync();
            return PartialView();
        }

        [Authorize("Permission")]
        public async Task<IActionResult> Edit(int id)
        {
            var discount = _discountService.GetById(id);
            ViewData["Users"] = await _userService.GetDefaultQuery()
                .Select(u => new SelectListItem() { Value = u.Id, Text = $"{u.FirstName} {u.LastName}", Selected = (u.Id == discount.UserId)}).ToListAsync();
            var model = new EditDiscountViewModel
            {
                Discount = discount,
                PersianValidFrom = discount.ValidFrom != null? new PersianDateTime(discount.ValidFrom.Value).ToString(PersianDateTimeFormat.Date).ToPersianDateStr() : null,
                PersianValidTo = discount.ValidTo != null? new PersianDateTime(discount.ValidTo.Value).ToString(PersianDateTimeFormat.Date).ToPersianDateStr() : null,
            };
            return PartialView(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Save(EditDiscountViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("Edit", model);

            var discount = model.Discount;
            if (model.Discount.UserId == "0")
                model.Discount.UserId = null;

            if (string.IsNullOrEmpty(model.PersianValidFrom) == false)
                discount.ValidFrom = model.PersianValidFrom.PersianDateToEnglishDate();   
            
            if (string.IsNullOrEmpty(model.PersianValidTo) == false)
                discount.ValidTo = model.PersianValidTo.PersianDateToEnglishDate();

            if (discount.Id == 0)
                discount.Code = _discountService.GenerateRandomCode();

            var savedDiscount = _discountService.AddOrUpdate(discount);
            return RedirectToAction("Index");
        }

        [Authorize("Permission")]
        public ActionResult Delete(int id)
        {
            var discount = _discountService.GetById(id);
            ViewBag.PersianFrom = discount.ValidFrom != null
                ? new PersianDateTime(discount.ValidFrom.Value).ToString(PersianDateTimeFormat.Date).ToPersianDateStr()
                : null;
            ViewBag.PersianTo = discount.ValidTo != null
                ? new PersianDateTime(discount.ValidTo.Value).ToString(PersianDateTimeFormat.Date).ToPersianDateStr()
                : null;
            return PartialView(discount);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _discountService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
