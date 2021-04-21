using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        [Route("Post/{id}")]
        public IActionResult Details(int id)
        {
            var post = _postService.GetPostDetail(id);
            _postService.UpdatePostViewCount(id);
            return View(post);
        }

        [Route("PostCategory/{id}")]
        public IActionResult PostCategory(int id)
        {
            var model = new PostsByCategoryViewModel();

            var items = _postService.GetPostByCategory(id);

            model.CategoryTitle = _categoryService.GetById(id)?.Title;
            model.PostList = items;
            model.BestPosts = items.OrderByDescending(p => p.ViewCount).Take(6).ToList();

            return View(model);
        }
    }
}
