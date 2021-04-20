using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace TvPlus.Web.Components
{
	public class MenuCategoryViewComponent : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public MenuCategoryViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await _categoryService.GetMainMenuItemsAsync();

			return View(items);
		}
	}
}
