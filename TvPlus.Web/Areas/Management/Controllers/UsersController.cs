using DataTablesParser;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using TvPlus.DataAccess;
using TvPlus.Infrastructure.Dtos.User;
using Microsoft.EntityFrameworkCore;
using TvPlus.Web.ViewModels;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

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
        [Microsoft.AspNetCore.Authorization.Authorize("Permission")]
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
        [Microsoft.AspNetCore.Authorization.Authorize("Permission")]
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
        [Microsoft.AspNetCore.Authorization.Authorize("Permission")]
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
        public async Task<IActionResult> EditMyProfile()
        {
            var currentUser = await _userService.GetCurrentUser();
            if (currentUser == null)
            {
                return NotFound();
            }
            var model = new EditUserViewModel
            {
                Id = currentUser.Id,
                UserName = currentUser.UserName,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                PhoneNumber = currentUser.PhoneNumber,
                Email = currentUser.Email,
                Information = currentUser.Information,
                Avatar = currentUser.Avatar
            };
            return View(model);
        }


        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> EditMyProfile(EditUserViewModel user, IFormFile UserAvatar)
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
                return RedirectToAction("Index", "Dashboard");
            }

            return View(user);

        }
        public ActionResult ResetMyPassword(string id)
        {
            return PartialView();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IdentityResult> ResetMyPassword(ResetMyPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userService.GetCurrentUser();
                var result = await _userManager.ChangePasswordAsync(currentUser, model.OldPassword, model.Password);
                return result;
            }
            return IdentityResult.Failed();
        }
        [Microsoft.AspNetCore.Authorization.Authorize("Permission")]
        public async Task<IActionResult> EditRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            ViewBag.Email = user?.Email;
            ViewBag.UserId = user?.Id;

            var allRoles = await _roleManager.Roles.ToListAsync();
            var roles = allRoles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Selected = userRoles.Contains(x.Name)
            }).ToList();
            return View(roles);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> EditRoles(string userId, List<RoleViewModel> roles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userId);
                var userRoles = await _userManager.GetRolesAsync(user);

                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, roles.Where(x => x.Selected).Select(x => x.Name));

                return RedirectToAction(nameof(Index));
            }

            return View(roles);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IdentityResult> ResetPasswordToDefault(string id)
        {
            var result = await _userService.ResetPasswordToDefault(id);
            return result;
        }
        [Microsoft.AspNetCore.Authorization.Authorize("Permission")]
        public async Task<ActionResult> Delete(string id)
        {
            return PartialView(await _userService.GetById(id));
        }
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}
