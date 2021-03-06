using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class CommentController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public CommentController(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }
        [Authorize("Permission")]
        public IActionResult PostComments(int id, bool root = false)
        {
            ViewBag.Root = root;
            ViewBag.PostId = id;
            ViewBag.PostName = _postService.GetById(id).ShortTitle;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public string LoadGrid(int? centerId = null)
        {
            var comments = _commentService.GetCommentTableQuery(centerId)
                .Select(p => new CommentTable()
                {
                    Id = p.Id,
                    Writer = $"{p.User.FirstName} {p.User.LastName}",
                    Subject = p.Center.ShortTitle,
                    Message = p.Message,
                    Show = p.Show
                }).AsQueryable();

            var parser = new Parser<CommentTable>(Request.Form, comments);
            return JsonConvert.SerializeObject(parser.Parse());
        }

        [Authorize("Permission")]
        public IActionResult Create(int? centerId)
        {
            ViewBag.CenterId = centerId;
            return PartialView();
        }

        [Authorize("Permission")]
        public IActionResult Edit(int id)
        {
            return PartialView(_commentService.GetForEdit(id));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Save(EditCommentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(nameof(Edit), model);

            var savedComment = await _commentService.Save(model);
            return RedirectToAction(nameof(PostComments),new {id = savedComment.CenterId});
        }
        [Authorize("Permission")]
        public ActionResult Delete(int id)
        {
            return PartialView(_commentService.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var centerId = _commentService.GetForEdit(id).CenterId;
            _commentService.Delete(id);
            return RedirectToAction(nameof(PostComments), new { id = centerId });

        }

        public IActionResult ToggleShow(int id)
        {
            var comment = _commentService.GetById(id);
            comment.Show = !comment.Show;
            _commentService.Update(comment);
            return RedirectToAction(nameof(PostComments), new { id = comment.CenterId });
        }
    }
}
