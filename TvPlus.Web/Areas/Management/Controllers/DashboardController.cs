using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Http;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.Services;
using TvPlus.Infrastructure.ViewModels;
using TvPlus.Infrastructure.Wrappers;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    //[Authorize(Roles = "Superuser")]
    public class DashboardController : Controller
    {
        private readonly ICenterService _centerService;
        private readonly IVideoService _videoService;
        private readonly IBackgroundJobClient _backgroundJob;

        public DashboardController(ICenterService centerService, IVideoService videoService, IBackgroundJobClient backgroundJob)
        {
            _centerService = centerService;
            _videoService = videoService;
            _backgroundJob = backgroundJob;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Management/UploadVideo")]
        [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
             ValueLengthLimit = int.MaxValue)]
        public async Task<IActionResult> UploadVideo(int? id, IFormFile file)
        {
            try
            {
                if (id == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response<dynamic> { Succeeded = false, Message = "آیتم مورد نظر پیدا نشد" });
                var center = _centerService.GetById(id.Value);

                if (center == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response<dynamic> { Succeeded = false, Message = "آیتم مورد نظر پیدا نشد" });
                if (file == null || file.Length <= 0)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response<dynamic> { Succeeded = false, Message = "ویدیو پیدا نشد" });

                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", "Videos");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                var fileName = id + "-(" + DateTime.Now.ToString("yyyy-M-d-hhmmss") + ")" + Path.GetExtension(file.FileName);
                var finalPath = Path.Combine(uploadFolder, fileName);

                await using (var fileStream = new FileStream(finalPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                var video = _videoService.AddVideo(id.Value, fileName);

                var conversionHelper = new ConversionHelper(_videoService);
                _backgroundJob.Enqueue(() => conversionHelper.ConvertVideo(video));

                var oldVideo = _videoService.GetByCenterId(id.Value);
                if (oldVideo != null)
                {
                    _videoService.Delete(oldVideo);
                    var videoConverts = _videoService.GetVideoConverts(oldVideo.Id);
                    foreach (var item in videoConverts)
                    {
                        _videoService.DeleteVideoConvert(item.Id);
                    }
                }
                return Ok(new Response<dynamic>(finalPath) { Message = "ویدیو با موفقیت آپلود شد" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<dynamic> { Succeeded = false, Message = e.ToString() + "آپلود ویدیو با خطا مواجه شد" });
            }
        }
    }
}
