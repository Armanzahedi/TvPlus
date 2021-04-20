using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Services;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        [Authorize("Permission")]
        public IActionResult Index()
        {
            return View(_aboutUsService.GetDefaultQuery().FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Save(AboutUs model)
        {
            var aboutUs = _aboutUsService.GetAboutUs();
            aboutUs.Title = model.Title;
            aboutUs.Description = model.Description;
            _aboutUsService.Update(aboutUs);
            return Ok();
        }
        public IActionResult SectionsTable()
        {
            return PartialView(_aboutUsService.GetAboutUsSections());
        }

        public IActionResult EditSection(int id)
        {
            return PartialView(_aboutUsService.GetSectionById(id));
        }
        [HttpPost]
        public IActionResult EditSection(AboutUsSection model)
        {
            var section = _aboutUsService.GetSectionById(model.Id);
            section.Title = model.Title;
            section.Description = model.Description;
            _aboutUsService.UpdateSection(section);
            return Ok();
        }
    }
}
