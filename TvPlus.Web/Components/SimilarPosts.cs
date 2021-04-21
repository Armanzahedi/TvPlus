using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;
using TvPlus.Infrastructure.Services;

namespace TvPlus.Web.Components
{
    public class SimilarPostsViewComponent : ViewComponent
    {
        private readonly IPostService _postService;

        public SimilarPostsViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int postId, int take)
        {
            var items = await _postService.GetSimilarPosts(postId, take);
            return View(items);
        }
    }
}
