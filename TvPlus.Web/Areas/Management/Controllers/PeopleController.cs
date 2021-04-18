
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
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly IImageService _imageService;
        public PeopleController(IPeopleService peopleService, IImageService imageService)
        {
            _peopleService = peopleService;
            _imageService = imageService;
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
            var people = _peopleService.GetDefaultQuery().Select(p => new PeopleGridViewModel
                {Id = p.Id, Name = $"{p.Firstname} {p.Lastname}"}).AsQueryable();

            var form = Request.Form;
            var parser = new Parser<PeopleGridViewModel>(Request.Form, people);
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
            return PartialView(_peopleService.GetPeopleForEdit(id));
        }
        [HttpPost]  
        [AllowAnonymous]
        public async Task<IActionResult> Save(EditPeopleViewModel model,IFormFile PeopleImage)
        {
            if (!ModelState.IsValid)
                return PartialView(nameof(Edit), model);

            var savedPeople = _peopleService.Save(model);
            if (PeopleImage != null)
            {
                var image = _imageService.GetByCenterId(savedPeople.Id) ?? new Image { CenterId = savedPeople.Id };

                var imageName = await ImageHelper.SaveImage(PeopleImage, 200, 200, true);
                image.ImageName = imageName;
                _imageService.AddOrUpdate(image);
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize("Permission")]
        public ActionResult Delete(int id)
        {
            return PartialView(_peopleService.GetPeopleForEdit(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _peopleService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
