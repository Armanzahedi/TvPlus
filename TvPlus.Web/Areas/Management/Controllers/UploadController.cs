using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using TvPlus.Infrastructure.Helpers;
using TvPlus.Infrastructure.Services;

namespace TvPlus.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class UploadController : Controller
    {
        private readonly ICenterService _centerService;
        private readonly IVideoService _videoService;
        private readonly IBackgroundJobClient _backgroundJob;
        public UploadController(IBackgroundJobClient backgroundJob, IVideoService videoService, ICenterService centerService)
        {
            _backgroundJob = backgroundJob;
            _videoService = videoService;
            _centerService = centerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Management/Upload/Video")]
        [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
        ValueLengthLimit = int.MaxValue)]
        public async Task<IActionResult> Index(IFormFile file)
        {
            try
            {
                if (file == null || file.Length <= 0)
                    return View();

                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", "Videos");
                var fileName = "id" + "-(" + DateTime.Now.ToString("yyyy-M-d-hhmmss") + ")" + Path.GetExtension(file.FileName);
                var finalPath = Path.Combine(uploadFolder, fileName);

                await using (var fileStream = new FileStream(finalPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                //var video = _videoService.AddVideo(id.Value, finalPath);

                //var conversionHelper = new ConversionHelper(_videoService);
                //_backgroundJob.Enqueue(() => conversionHelper.ConvertVideo(video));

                //var oldVideo = _videoService.GetByCenterId(id.Value);
                //if (oldVideo != null)
                //{
                //    _videoService.Delete(oldVideo);
                //}
                return Ok( new { Message = "UploadDone"});
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {Message = e.ToString() + "UploadFailed" }); ;
            }
        }
    }
}
