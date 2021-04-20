using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Infrastructure.Services;

namespace TvPlus.Web.Components
{
    public class TrendTvViewComponent : ViewComponent
    {
        private readonly IPostService _postService;

        public TrendTvViewComponent(IPostService PostService)
        {
            _postService = PostService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _postService.GetTrendTvsAsync();

            return View(items);
        }
    }
}
