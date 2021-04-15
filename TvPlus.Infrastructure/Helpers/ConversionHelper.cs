using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.Infrastructure.Services;
using TvPlus.Utility.Enums;
using Xabe.FFmpeg;

namespace TvPlus.Infrastructure.Helpers
{
   public class ConversionHelper
   {
       private readonly IVideoService _videoService;

       public ConversionHelper(IVideoService videoService)
       {
           _videoService = videoService;
       }

       public async Task ConvertVideo(Video video)
        {
            try
            {
                video.ConversionStatus = ConversionStatus.Processing;
                _videoService.Update(video);

                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"UploadedFiles","Videos",video.VideoName);
                var mediaInfo = await FFmpeg.GetMediaInfo(filePath);
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var frameWidth = mediaInfo.VideoStreams.First().Width;
                var outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", "VideoConverts");
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }
                if (frameWidth > 320)
                {
                    var convertedName = fileName + "_320" + Path.GetExtension(filePath);
                    var outputPath = Path.Combine(outputFolder, convertedName);

                    IStream videoStream = mediaInfo.VideoStreams.FirstOrDefault()
                        ?.SetSize(VideoSize.Hvga);
                    IStream audioStream = mediaInfo.AudioStreams.FirstOrDefault()
                        ?.SetCodec(AudioCodec.aac);

                    await FFmpeg.Conversions.New()
                        .AddStream(audioStream, videoStream)
                        .SetOutput(outputPath)
                        .Start();

                    _videoService.AddConvertedVideo(video.Id, 320, outputPath);
                }
                if (frameWidth > 480)
                {
                    var convertedName = fileName + "_480" + Path.GetExtension(filePath);
                    var outputPath = Path.Combine(outputFolder, convertedName);

                    IStream videoStream = mediaInfo.VideoStreams.FirstOrDefault()
                        ?.SetSize(VideoSize.Hd480);
                    IStream audioStream = mediaInfo.AudioStreams.FirstOrDefault()
                        ?.SetCodec(AudioCodec.aac);

                    await FFmpeg.Conversions.New()
                        .AddStream(audioStream, videoStream)
                        .SetOutput(outputPath)
                        .Start();

                    _videoService.AddConvertedVideo(video.Id, 480, outputPath);
                }
                if (frameWidth > 720)
                {
                    var convertedName = fileName + "_720" + Path.GetExtension(filePath);
                    var outputPath = Path.Combine(outputFolder, convertedName);

                    IStream videoStream = mediaInfo.VideoStreams.FirstOrDefault()
                        ?.SetSize(VideoSize.Hd720);
                    IStream audioStream = mediaInfo.AudioStreams.FirstOrDefault()
                        ?.SetCodec(AudioCodec.aac);

                    await FFmpeg.Conversions.New()
                        .AddStream(audioStream, videoStream)
                        .SetOutput(outputPath)
                        .Start();

                    _videoService.AddConvertedVideo(video.Id, 720, outputPath);
                }
                if (frameWidth > 1080)
                {
                    var convertedName = fileName + "_1080" + Path.GetExtension(filePath);
                    var outputPath = Path.Combine(outputFolder, convertedName);

                    IStream videoStream = mediaInfo.VideoStreams.FirstOrDefault()
                        ?.SetSize(VideoSize.Hd1080);
                    IStream audioStream = mediaInfo.AudioStreams.FirstOrDefault()
                        ?.SetCodec(AudioCodec.aac);

                    await FFmpeg.Conversions.New()
                        .AddStream(audioStream, videoStream)
                        .SetOutput(outputPath)
                        .Start();

                    _videoService.AddConvertedVideo(video.Id, 1080, outputPath);
                }

                video.ConversionStatus = ConversionStatus.Done;
                _videoService.Update(video);
            }
            catch (Exception e)
            {
                video.ConversionStatus = ConversionStatus.Failed;
                _videoService.Update(video);
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
