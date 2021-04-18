using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class SpecialOffersController : Controller
    {
        private readonly IPostService _postService;
        public SpecialOffersController(IPostService postService)
        {
            _postService = postService;
        }
        [Authorize("Permission")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public string LoadGrid()
        {
            var posts = _postService.GetDefaultQuery().Select(item =>
                new SpecialOfferGridViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    IsSpecialOffer = item.IsSpecialOffer
                }
            ).AsQueryable();
            var form = Request.Form;
            var parser = new Parser<SpecialOfferGridViewModel>(Request.Form, posts);
            var data = parser.Parse();
            return JsonConvert.SerializeObject(parser.Parse());
        }
        [Authorize("Permission")]
        public IActionResult ToggleStatus(int id)
        {
            var post = _postService.GetById(id);
            return PartialView(post);
        }
        [HttpPost, ActionName("ToggleStatus")]
        public ActionResult ToggleStatusConfirmed(int id)
        {
            var post = _postService.GetById(id);

            post.IsSpecialOffer = !post.IsSpecialOffer;

            _postService.Update(post);
            return RedirectToAction(nameof(Index));
        }
    }
}
