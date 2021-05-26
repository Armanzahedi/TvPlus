using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;

        public PostController(IPostService postService, ICategoryService categoryService, ICommentService commentService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        [Route("Post/{id}/{string}")]
        public IActionResult Details(int id)
        {
            var post = _postService.GetPostDetail(id);
            _postService.UpdatePostViewCount(id);
            return View(post);
        }

        [Route("PostCategory/{id}/{string}")]
        public IActionResult PostCategory(int id)
        {
            var model = new PostsByCategoryViewModel();

            var items = _postService.GetPostByCategory(id);

            model.CategoryTitle = _categoryService.GetById(id)?.Title;
            model.PostList = items;
            model.BestPosts = items.OrderByDescending(p => p.ViewCount).Take(6).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitComment(SubmitCommentViewModel model)
        {
            try
            {
                var comment = new EditCommentViewModel()
                {
                    CenterId = model.CenterId,
                    Message = model.Message
                };
                 await _commentService.Save(comment);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
