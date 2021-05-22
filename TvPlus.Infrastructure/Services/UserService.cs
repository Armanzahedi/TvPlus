using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Dtos.User;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Infrastructure.Services
{
    public interface IUserService
    {
        IQueryable<User> GetDefaultQuery();
        Task<User> GetById(string id);
        Task<User> CreateUser(User model, string Password);
        Task<Tuple<User, bool>> UpdateUser(EditUserViewModel model);
        Task<IdentityResult> Remove(string id);
        Task<bool> UserNameExists(string username, string id = null);
        Task<bool> EmailExists(string email, string id = null);
        Task<User> UploadUserImage(string id, IFormFile file);
        Task<User> GetUserByUserName(string userName);
        Task<List<User>> GetUsers(PaginationFilter pagination, string searchString);
        IQueryable<User> FilterUsers(string searchString = null);
        Task<User> GetCurrentUser();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;
        public readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HttpContextAccessor _httpContext;


        public UserService(
            IUserRepository userRepository,
            IMapper mapper, MyDbContext context,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContext ??= new HttpContextAccessor();

        }

        public IQueryable<User> GetDefaultQuery()
        {
            return _context.Users;
        }


        public async Task<User> GetById(string id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> Create(UserCreateDto model)
        {
            var entity = _mapper.Map<User>(model);
            return await _userRepository.Add(entity);
        }

        public async Task<IdentityResult> Remove(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;

            var userRoles = await _context.UserRoles.Where(r => r.UserId == user.Id).ToListAsync();
            foreach (var role in userRoles)
                _context.UserRoles.Remove(role);
            _context.SaveChanges();

            if (user.Avatar != null)
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", user.Avatar)))
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", user.Avatar));

            var result = await _userManager.DeleteAsync(user);
            return result;
        }

        public async Task<bool> UserNameExists(string username, string id = null)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                if (string.IsNullOrEmpty(id))
                {
                    if (user != null)
                        return true;
                }
                else
                {
                    if (user.Id != id)
                        return true;
                }
            }

            return false;
        }

        public async Task<bool> EmailExists(string email, string id = null)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (string.IsNullOrEmpty(id))
                {
                    if (user != null)
                        return true;
                }
                else
                {
                    if (user.Id != id)
                        return true;
                }
            }

            return false;
        }

        public async Task<User> UploadUserImage(string id, IFormFile file)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user.Avatar != null)
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", user.Avatar)))
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", user.Avatar));

            var imageName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "UserAvatar", imageName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            user.Avatar = imageName;
            return user;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName.ToLower());
            return user;
        }
        public IQueryable<User> FilterUsers(string searchString = null)
        {
            IQueryable<User> users = null;

            users = _userManager.Users;

            if (searchString != null)
                users = _userManager.Users
                    .Where(u => u.UserName.ToLower().Contains(searchString.ToLower()) || u.Email.ToLower().Contains(searchString.ToLower()));
            return users;
        }

        public async Task<User> GetCurrentUser()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = _httpContext.HttpContext.User;

            return await _userManager.GetUserAsync(currentUser);
        }

        private static List<string> GetRoles(MyDbContext _context,string userId)
        {
            var roleIds = _context.UserRoles
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId)
                .ToList();

            var roles = _context.Roles
                .Where(x => roleIds.Contains(x.Id))
                .Select(r=>r.Name).ToList();


            return roles;
        }

        public async Task<List<User>> GetUsers(PaginationFilter pagination, string searchString = null)
        {
            var usersList = new List<UserInfoDto>();

            var users = FilterUsers(searchString);

            users = users.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize);


            return await users.ToListAsync();
        }
        public async  Task<User> CreateUser(User model, string Password)
        {
            model.SecurityStamp = Guid.NewGuid().ToString();
            await _userManager.CreateAsync(model, Password);

            return model;
        }
        public async Task<Tuple<User, bool>> UpdateUser(EditUserViewModel model)
        {
            var succeeded = true;
            var prevUser = _context.Users.Find(model.Id);
            prevUser.Email = model.Email;
            prevUser.FirstName = model.FirstName;
            prevUser.LastName = model.LastName;
            prevUser.UserName = model.UserName;
            prevUser.Information = model.Information;
            prevUser.PhoneNumber = model.PhoneNumber;
            prevUser.Avatar = model.Avatar;

            _context.Entry(prevUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            //_userManager.Update(model);
            //if (!string.IsNullOrEmpty(newPassword))
            //{
            //    var userPrevPassword = model.PasswordHash; // keeping prev password just in case setting new password fails
            //    var removePassword = _userManager.RemovePassword(model.Id);
            //    if (removePassword.Succeeded)
            //    {
            //        var addPassword = _userManager.AddPassword(model.Id, newPassword);
            //        if (addPassword.Succeeded == false)
            //        {
            //            succeeded = false;
            //            model.PasswordHash = userPrevPassword;
            //            _context.Entry(model).State = EntityState.Modified;
            //            _context.SaveChanges();
            //            //_userManager.Update(model);
            //        }
            //    }
            //}
            var updateModel = new Tuple<User, bool>(prevUser, succeeded);
            return updateModel;
        }

    }
}
