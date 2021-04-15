using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Dtos.User;

namespace TvPlus.Infrastructure.Services
{
    public interface IAuthService
    {
        //Task<JwtSecurityToken> Login(UserLoginDto model);
        Task<User> Register(UserRegisterDto model);
        Task<bool> UserExists(string username, string id = null);
        Task<bool> EmailExists(string email, string id = null);
    }
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        //public async Task<JwtSecurityToken> Login(UserLoginDto model)
        //{
        //    var user = await _userManager.FindByNameAsync(model.UserName);

        //    // in case the input is the user's email address
        //    if (user == null)
        //        user = await _userManager.FindByEmailAsync(model.UserName);

        //    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        //    {
        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        var authClaims = new List<Claim>
        //        {
        //            new Claim("unique_name", user.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        };

        //        foreach (var userRole in userRoles)
        //        {
        //            authClaims.Add(new Claim("role", userRole));
        //        }
        //        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        //        var token = new JwtSecurityToken(
        //            issuer: _configuration["JWT:ValidIssuer"],
        //            audience: _configuration["JWT:ValidAudience"],
        //            expires: DateTime.Now.AddHours(3),
        //            claims: authClaims,
        //            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //            );
        //        return token;
        //    }
        //    return null;
        //}
        public async Task<User> Register(UserRegisterDto model)
        {
            var user = new User()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Information = model.Information
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("Admin"))
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                if (!await _roleManager.RoleExistsAsync("Author"))
                    await _roleManager.CreateAsync(new IdentityRole("Author"));

                await _userManager.AddToRoleAsync(user, "Author");
                await _userManager.RemoveFromRoleAsync(user, "Admin");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            return user;
        }
        public async Task<bool> UserExists(string username, string id = null)
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
    }
}
