using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IPeopleService _peopleService;
        private readonly ITagService _tagsService;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoriesService;
        public PostsController(IPostService postService, IPeopleService peopleService, ITagService tagsService, IImageService imageService, ICategoryService categoriesService)
        {
            _postService = postService;
            _peopleService = peopleService;
            _tagsService = tagsService;
            _imageService = imageService;
            _categoriesService = categoriesService;
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
            new PostGridViewModel
            {
                Id = item.Id,
                Title = item.Title,
                PublishDate = new PersianDateTime(item.PublishDate).ToString(),
                ViewCount = item.ViewCount,
            }
            ).AsQueryable();
            var form = Request.Form;
            var parser = new Parser<PostGridViewModel>(Request.Form, posts);
            return JsonConvert.SerializeObject(parser.Parse());
        }
        [Authorize("Permission")]
        public IActionResult Create()
        {
            ViewBag.People = _peopleService.GetDefaultQuery().Select(p=>$"{p.Firstname} {p.Lastname}").ToList();
            ViewBag.Tags = _tagsService.GetDefaultQuery().Select(p => p.Title).ToList();
            ViewBag.Categories = _categoriesService.GetDefaultQuery().Where(c=>c.IsDeleted == false)
                .Select(c => new PostCategoriesSelectList { Id = c.Id, Title = c.Title, Selected = false});
            return View();
        }
        [Authorize("Permission")]
        public IActionResult Edit(int id)
        {
            ViewBag.People = _peopleService.GetDefaultQuery().Select(p => $"{p.Firstname} {p.Lastname}").ToList();
            ViewBag.Tags = _tagsService.GetDefaultQuery().Select(p => p.Title).ToList();

            var vm = _postService.GetPostForEdit(id);

            ViewBag.Categories = _categoriesService.GetDefaultQuery().Where(c => c.IsDeleted == false)
                .Select(c => new PostCategoriesSelectList { Id = c.Id, Title = c.Title, Selected = vm.SelectedCategories.Any(selectedCatId => selectedCatId == c.Id) });
            return View(vm);
        }
        [HttpPost]
        public IActionResult SavePost(EditPostViewModel post)
        {
            try
            {
               
                var savedPost = _postService.SavePost(post);

                // if in create mode marking post delete until video and image gets upload
                if (post.EditMode == EditMode.Create)
                {
                    savedPost.IsDeleted = true;
                    _postService.Update(savedPost);
                }
                return Ok(new { message = "success", data = savedPost.Id });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = e.ToString() + "خطا" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> SubmitPostImage(int id ,IFormFile File)
        {
            try
            {
                if (File != null)
                {

                    var image = _imageService.GetByCenterId(id) ?? new Image { CenterId = id };

                    var imageName = await ImageHelper.SaveImage(File, 800, 400, true);

                    image.ImageName = imageName;
                    _imageService.AddOrUpdate(image);
                }
                else
                {
                    var image = _imageService.GetByCenterId(id);
                    if (image == null)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "تصویر را وارد کنید" });
                    }
                }
                var post = _postService.GetById(id);
                post.IsDeleted = false;
                _postService.Update(post);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = e.ToString() + "خطا" });
            }
        }
        [Authorize("Permission")]
        public ActionResult Delete(int id)
        {
            return PartialView(_postService.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _postService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
