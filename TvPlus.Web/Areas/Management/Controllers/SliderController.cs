using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class SliderController : Controller
    {
        private readonly ISliderService _SliderService;
        private readonly IImageService _imageService;
        private readonly IPostService _postService;
        public SliderController(ISliderService SliderService, IImageService imageService, IPostService postService)
        {
            _SliderService = SliderService;
            _imageService = imageService;
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
            var Slider = _SliderService.GetDefaultQuery().Select(p => new SliderGridViewModel
            { Id = p.Id, Title = p.Title, PostTitle = p.Post.Title }).AsQueryable();

            var form = Request.Form;
            var parser = new Parser<SliderGridViewModel>(Request.Form, Slider);
            return JsonConvert.SerializeObject(parser.Parse());
        }
        [Authorize("Permission")]
        public IActionResult Create()
        {
            ViewData["Posts"] = _postService.GetDefaultQuery().Select(p=>new SelectListItem(){Text = p.ShortTitle,Value = p.Id.ToString()});
            return PartialView();
        }
        [Authorize("Permission")]
        public IActionResult Edit(int id)
        {
            return PartialView(_SliderService.GetById(id));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Save(Slider model, IFormFile SliderImage)
        {
            if (!ModelState.IsValid)
                return PartialView(nameof(Edit), model);

            if (SliderImage != null)
            {
                var imageName = await ImageHelper.SaveImage(SliderImage, 1800, 600, true);
                model.Image = imageName;
            }
            var savedSlider = _SliderService.Save(model);

            return RedirectToAction(nameof(Index));
        }
        [Authorize("Permission")]
        public ActionResult Delete(int id)
        {
            return PartialView(_SliderService.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _SliderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
