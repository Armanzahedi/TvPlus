using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var SUPER_USER_ID = "75625814-138e-4831-a1ea-bf58e211acmf";
            var SUPER_USER_ROLE_ID = "29bd76db-5835-406d-ad1d-7a0901448abd";
            var ADMIN_ID = "75625814-138e-4831-a1ea-bf58e211adff";
            var ADMIN_ROLE_ID = "29bd76db-5835-406d-ad1d-7a0901447c18";
            var USER_ROLE_ID = "d7be43da-622c-4cfe-98a9-5a5161120d24";
            var admin = new User()
            {
                Id = ADMIN_ID,
                Avatar = "user-avatar.png",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@Admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM"
            };
            var superuser = new User()
            {
                Id = SUPER_USER_ID,
                Avatar = "user-avatar.png",
                FirstName = "Superuser",
                LastName = "Superuser",
                UserName = "Superuser",
                NormalizedUserName = "SUPERUSER",
                Email = "Superuser@Superuser.com",
                NormalizedEmail = "SUPERUSER@SUPERUSER.COM"
            };
            superuser.PasswordHash = GetHashedPassword(superuser, "Superuser");

            modelBuilder.Entity<User>().HasData(
                admin,
                superuser
            );
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = USER_ROLE_ID, Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = SUPER_USER_ROLE_ID, Name = "Superuser", NormalizedName = "SUPERUSER" }
            );
            //modelBuilder.Entity<NavigationMenu>().HasData(
            //new NavigationMenu()
            //{
            //    Id = new Guid("F704BDFD-D3EA-4A6F-9463-DA47ED3657AB"),
            //    Name = "External Google Link",
            //    ControllerName = "",
            //    ActionName = "",
            //    IsExternal = true,
            //    ExternalUrl = "https://www.google.com/",
            //    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
            //    DisplayOrder = 2,
            //    Visible = true,
            //},
            //new NavigationMenu()
            //{
            //    Id = new Guid("913BF559-DB46-4072-BD01-F73F3C92E5D5"),
            //    Name = "Create Role",
            //    ControllerName = "Admin",
            //    ActionName = "CreateRole",
            //    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
            //    DisplayOrder = 3,
            //    Visible = true,
            //},
            //new NavigationMenu()
            //{
            //    Id = new Guid("3C1702C5-C34F-4468-B807-3A1D5545F734"),
            //    Name = "Edit User",
            //    ControllerName = "Admin",
            //    ActionName = "EditUser",
            //    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
            //    DisplayOrder = 3,
            //    Visible = false,
            //},
            //new NavigationMenu()
            //{
            //    Id = new Guid("94C22F11-6DD2-4B9C-95F7-9DD4EA1002E6"),
            //    Name = "Edit Role Permission",
            //    ControllerName = "Admin",
            //    ActionName = "EditRolePermission",
            //    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
            //    DisplayOrder = 3,
            //    Visible = false,
            //}
            //);

        }
        public static string GetHashedPassword(User user, string password)
        {
            var pass = new PasswordHasher<User>();
            var hashed = pass.HashPassword(user, password);
            return hashed;
        }
    }
}
