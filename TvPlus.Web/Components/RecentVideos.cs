using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Infrastructure.Services;

namespace TvPlus.Web.Components
{
    public class RecentVideosViewComponent : ViewComponent
    {
        private readonly IPostService _postService;

        public RecentVideosViewComponent(IPostService PostService)
        {
            _postService = PostService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _postService.GetRecentVideosAsync(6);

            return View(items);
        }
    }
}
