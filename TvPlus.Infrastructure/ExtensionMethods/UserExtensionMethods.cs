using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TvPlus.Core.Models;
using TvPlus.DataAccess;

namespace TvPlus.Infrastructure.ExtensionMethods
{
    //public static class UserExtensionMethods
    //{
    //    public static List<string> GetRoles(this User user)
    //    {
    //        using (var _userManager = new UserManager<User>())
    //        {
    //            var roleIds = _context.UserRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.RoleId).ToList();
    //            var roles = new List<string>();
    //            if (roleIds.Any())
    //            {
    //                foreach (var id in roleIds)
    //                {
    //                    var roleName = _context.Roles.FirstOrDefault(r => r.Id == id)?.Name;
    //                    if (roleName != null)
    //                    {
    //                        roles.Add(roleName);
    //                    }
    //                }
    //            }
    //            return roles;
    //        }
    //    }
    //}
}
