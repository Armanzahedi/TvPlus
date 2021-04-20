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

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class ContactUsInfoController : Controller
    {
        private readonly IContactUsInfoService _contactUsInfoService;
        public ContactUsInfoController(IContactUsInfoService contactUsService)
        {
            _contactUsInfoService = contactUsService;
        }
        [Authorize("Permission")]
        public IActionResult Index()
        {
            var model = _contactUsInfoService.GetFirst();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public string LoadGrid()
        {
            var form = Request.Form;
            var parser = new Parser<ContactUsInfo>(Request.Form, (IQueryable<ContactUsInfo>)_contactUsInfoService.GetDefaultQuery());
            var data = parser.Parse();
            return JsonConvert.SerializeObject(parser.Parse());
        }

        [HttpPost]
        public IActionResult Save(ContactUsInfo model)
        {
            var cui = _contactUsInfoService.GetFirst();
            cui.Title = model.Title;
            cui.Description = model.Description;
            cui.Instagram = model.Instagram;
            cui.Facebook = model.Facebook;
            cui.Twitter = model.Twitter;
            cui.Youtube = model.Youtube;

            _contactUsInfoService.Update(cui);
            return Ok();
        }
    }
}
