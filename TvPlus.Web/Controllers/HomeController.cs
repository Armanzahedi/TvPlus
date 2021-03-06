using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using TvPlus.Web.Models;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactUsInfoService _contactUsInfoService;
        private readonly IAboutUsService _aboutUsService;

        public HomeController(ILogger<HomeController> logger, IContactUsInfoService ContactUsInfoService, IAboutUsService AboutUsService)
        {
            _logger = logger;
            _contactUsInfoService = ContactUsInfoService;
            _aboutUsService = AboutUsService;
        }

        public IActionResult Index()
        {
            #region SEO
            ViewData["Title"] = "خانه";
            ViewData["MetaDescription"] = "خانه";
            #endregion

            return View();
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            #region SEO
            ViewData["Title"] = "ارتباط با ما";
            ViewData["MetaDescription"] = "ارتباط با ما";
            #endregion

            var item = _contactUsInfoService.GetFirst();
            return View(item);
        }

        [Route("AboutUs")]
        public IActionResult AboutUs()
        {
            #region SEO
            ViewData["Title"] = "درباره ما";
            ViewData["MetaDescription"] = "درباره ما";
            #endregion

            var aboutUs = _aboutUsService.GetAboutUs();
            var aboutUsSection = _aboutUsService.GetAboutUsSections();

            var model = new AboutUsViewModel
            {
                AboutUs = aboutUs,
                AboutUsSections = aboutUsSection
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult CkUploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string vImagePath = String.Empty;
            string vMessage = String.Empty;
            string vFilePath = String.Empty;
            string vOutput = String.Empty;
            try
            {
                if (upload != null)
                {
                    var vFileName = DateTime.Now.ToString("yyyyMMdd-HHMMssff") +
                                    Path.GetExtension(upload.FileName).ToLower();
                    var vFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", "Images");
                    if (!Directory.Exists(vFolderPath))
                    {
                        Directory.CreateDirectory(vFolderPath);
                    }
                    vFilePath = Path.Combine(vFolderPath, vFileName);
                    using (var fileStream = new FileStream(vFilePath, FileMode.Create))
                    {
                        upload.CopyTo(fileStream);
                    }
                    vImagePath = Url.Content("/UploadedFiles/Images/" + vFileName);
                    vMessage = "Image was saved correctly";
                }
            }
            catch
            {
                vMessage = "There was an issue uploading";
            }
            vOutput = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + vImagePath + "\", \"" + vMessage + "\");</script></body></html>";
            return Json(new { uploaded = "true", url = vImagePath });
        }

    }
}
