using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using TvPlus.DataAccess;
using TvPlus.Infrastructure.Dtos.User;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    //[Authorize("Permission")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly MyDbContext _context;


        public UsersController(IUserService userService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, MyDbContext context)
        {
            _userService = userService;
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index(bool root = false)
        {
            ViewBag.Root = root;
            return View();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public string LoadGrid()
        {
            var usersGrid = _context.Users.Select(item =>
                new UserGridDto()
                {
                    Id = item.Id,
                    Email = item.Email,
                    Name = $"{item.FirstName} {item.LastName}",
                    Roles = _context.UserRoles.Where(ur => ur.UserId == item.Id).Select(ur => _context.Roles.FirstOrDefault(r => r.Id == ur.RoleId)).Select(r => r.Name).ToList()
                }
            );
            var parser = new Parser<UserGridDto>(Request.Form, usersGrid);
            return JsonConvert.SerializeObject(parser.Parse());
        }
        public ActionResult Create()
        {
            ViewBag.Message = null;
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel form, IFormFile UserAvatar)
        {
            if (ModelState.IsValid)
            {
                #region Check for duplicate username or email
                if (await _userService.UserNameExists(form.User.UserName))
                {
                    ModelState.AddModelError(string.Empty, "کاربر دیگری با همین نام در سیستم ثبت شده");
                    return View(form);
                }
                if (await _userService.EmailExists(form.User.Email))
                {
                    ModelState.AddModelError(string.Empty, "کاربر دیگری با همین ایمیل در سیستم ثبت شده");
                    return View(form);
                }
                #endregion

                #region Upload Image
                if (UserAvatar != null)
                {
                    var imageName = await ImageHelper.SaveImage(UserAvatar, 400, 400, "UserAvatars", true);

                    form.User.Avatar = imageName;
                }
                #endregion
                var userModel = form.User;

                await _userManager.CreateAsync(userModel, form.Password);
                await _userManager.AddToRoleAsync(userModel, "User");

                return RedirectToAction("Index");
            }

            return View(form);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Information = user.Information,
                Avatar = user.Avatar
            };
            return View(model);
        }


        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel user, IFormFile UserAvatar)
        {

            if (ModelState.IsValid)
            {
                #region Check for duplicate username or email
                if (await _userService.UserNameExists(user.UserName, user.Id))
                {
                    ModelState.AddModelError(string.Empty, "کاربر دیگری با همین نام در سیستم ثبت شده");
                    return View(user);
                }
                if (await _userService.EmailExists(user.Email, user.Id))
                {
                    ModelState.AddModelError(string.Empty, "کاربر دیگری با همین ایمیل در سیستم ثبت شده");
                    return View(user);
                }
                #endregion

                #region Upload Image
                if (UserAvatar != null)
                {
                    var imageName = await ImageHelper.SaveImage(UserAvatar, 400, 400, "UserAvatars", true);

                    user.Avatar = imageName;
                }
                #endregion
                var result = await _userService.UpdateUser(user);
                return RedirectToAction("Index");
            }

            return View(user);

        }
        // [Authorize("Permission")]
        public ActionResult Delete(string id)
        {
            return PartialView(_userService.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}
