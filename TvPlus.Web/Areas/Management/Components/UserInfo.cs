using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Services;

namespace TvPlus.Web.Areas.Management.Components
{
    public class UserInfoViewComponent : ViewComponent
    {
        private UserManager<User> _userManager;

        public UserInfoViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }
    }
}
