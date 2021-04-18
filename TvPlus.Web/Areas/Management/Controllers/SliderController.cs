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
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IImageService _imageService;
        private readonly IPostService _postService;
        public SliderController(ISliderService sliderService, IImageService imageService, IPostService postService)
        {
            _sliderService = sliderService;
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
            var Slider = _sliderService.GetWithPostNavigation().Select(p => new SliderGridViewModel
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
            var slider = _sliderService.GetById(id);
            ViewData["Posts"] = _postService.GetDefaultQuery().Select(p => new SelectListItem() { Text = p.ShortTitle, Value = p.Id.ToString(), Selected = p.Id == slider.PostId});
            return PartialView(slider);
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
            var savedSlider = _sliderService.Save(model);

            return RedirectToAction(nameof(Index));
        }
        [Authorize("Permission")]
        public ActionResult Delete(int id)
        {
            return PartialView(_sliderService.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _sliderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
