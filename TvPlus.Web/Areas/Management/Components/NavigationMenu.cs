using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Web.Helpers;

namespace TvPlus.Web.Areas.Management.Components
{
	public class NavigationMenuViewComponent : ViewComponent
	{
		private readonly IRolePermissionService _rolePermissionService;

		public NavigationMenuViewComponent(IRolePermissionService rolePermissionService)
		{
			_rolePermissionService = rolePermissionService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await _rolePermissionService.GetMenuItemsAsync(HttpContext.User);

			return View(items);
		}
	}
}
