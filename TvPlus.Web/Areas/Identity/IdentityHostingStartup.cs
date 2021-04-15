using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TvPlus.Core.Models;

[assembly: HostingStartup(typeof(TvPlus.Web.Areas.Identity.IdentityHostingStartup))]
namespace TvPlus.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<MyDbContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("MyDbContextConnection")));

            //    services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<MyDbContext>();
            //});
        }
    }
}