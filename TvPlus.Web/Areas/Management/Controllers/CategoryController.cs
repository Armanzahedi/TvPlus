
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService;
        private readonly IImageService _imageService;
        public CategoryController(ICategoryService CategoryService, IImageService imageService)
        {
            _CategoryService = CategoryService;
            _imageService = imageService;
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
            var Category = _CategoryService.GetDefaultQuery().Select(p => new CategoryGridViewModel
                {Id = p.Id, Title =p.Title}).AsQueryable();

            var parser = new Parser<CategoryGridViewModel>(Request.Form, Category);
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
            return PartialView(_CategoryService.GetCategoryForEdit(id));
        }

        [HttpPost]  
        [AllowAnonymous]
        public async Task<IActionResult> Save(EditCategoryViewModel model,IFormFile CategoryImage)
        {
            if (!ModelState.IsValid)
                return PartialView(nameof(Edit), model);

            var savedCategory = _CategoryService.Save(model);
            if (CategoryImage != null)
            {
                var image = _imageService.GetByCenterId(savedCategory.Id) ?? new Image { CenterId = savedCategory.Id };

                var imageName = await ImageHelper.SaveImage(CategoryImage, 200, 200, true);
                image.ImageName = imageName;
                _imageService.AddOrUpdate(image);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize("Permission")]
        public ActionResult Delete(int id)
        {
            return PartialView(_CategoryService.GetCategoryForEdit(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _CategoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
