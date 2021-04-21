using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.Infrastructure;
using TvPlus.Infrastructure.Dtos.SystemParameter;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.ViewModels;
using TvPlus.Web.Areas.Identity.ViewModels;
using TvPlus.Web.Helpers;

namespace TvPlus.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebOptimizer(pipeline =>
            {

                //pipeline.AddCssBundle("/management/bundle.css",
                //    "wwwroot/management/myStyle.css",
                //    "wwwroot/management/plugins/global/plugins.bundle.rtl.css",
                //    "wwwroot/management/css/style.bundle.rtl.css",
                //    "wwwroot/management/css/themes/layout/header/base/light.rtl.css",
                //    "wwwroot/management/css/themes/layout/header/menu/light.rtl.css",
                //    "wwwroot/management/css/themes/layout/brand/dark.rtl.css",
                //    "wwwroot/management/css/themes/layout/aside/dark.rtl.css").UseContentRoot().MinifyCss().AdjustRelativePaths();

                //pipeline.AddJavaScriptBundle("/management/bundle.js",
                //    "wwwroot/management/plugins/global/plugins.bundle.js",
                //    "wwwroot/management/js/scripts.bundle.js",
                //    "wwwroot/management/js/pages/widgets.js").UseContentRoot().MinifyJavaScript();
            });
            services.AddControllersWithViews(setup =>
            {
            })
                .AddRazorRuntimeCompilation()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EditPeopleValidator>());
            services.AddRazorPages();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<MyDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<LocalizedIdentityErrorDescriber>();
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
                options.LoginPath = new PathString("/Identity/Account/Login");
            });
            services.AddDbContext<MyDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TvPlus.DataAccess"));
            }, ServiceLifetime.Transient);
            services.AddDataAccess();
            services.AddInfrastructure();
            services.AddSingleton<IEmailSender, EmailSender>();
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("fa");

            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();

            services.AddScoped<IUserPermissionHelper, UserPermissionHelper>();

            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")
        //    , new SqlServerStorageOptions
        //{
        //    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        //    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        //    QueuePollInterval = TimeSpan.Zero,
        //    UseRecommendedIsolationLevel = true,
        //    DisableGlobalLocks = true
        //}
        ));

            services.AddHangfireServer(opt => opt.WorkerCount = 1);


            services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
                    UnicodeRanges.Arabic }));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHangfireDashboard();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseWebOptimizer();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles")),
                RequestPath = "/UploadedFiles",

            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = string.Empty,

            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default-area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
