using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Web.Components
{
    public class PostCategoryViewComponent : ViewComponent
    {
        private readonly IPostService _postService;

        public PostCategoryViewComponent(IPostService PostService)
        {
            _postService = PostService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new PostCategoryViewModel();

            var recentVideos = await _postService.GetRecentVideosAsync(4);
            var mostViewed = await _postService.GetMostViewedPostAsync();
            var hottest = await _postService.GetHottestPostAsync();
            var Controversials = await _postService.GetControversialPostAsync();

            model.RecentVideos = recentVideos;
            model.MostViewedPost = mostViewed;
            model.HottestPost = hottest;
            model.ControversialPost = Controversials;
            
            return View(model);
        }
    }
}
