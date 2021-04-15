using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace TvPlus.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            FFmpegRun().GetAwaiter().GetResult();
            host.Run();
        }
        private static async Task FFmpegRun()
        {
            //var filesToConvert = new Queue<>(GetFilesToConvert(Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", "Videos")));
            //await Console.Out.WriteLineAsync($"Find {filesToConvert.Count} files to convert.");

            //Set directory where the app should look for FFmpeg executables.
            FFmpeg.SetExecutablesPath(Path.Combine(Environment.CurrentDirectory, "FFmpeg","bin"));
            //Get latest version of FFmpeg. It's great idea if you don't know if you had installed FFmpeg.
            //await FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official);
            ////Run conversion
            //await RunConversion(filesToConvert);

            //Console.In.ReadLine();
        }

        private static IEnumerable GetFilesToConvert(string directoryPath)
        {
            //Return all files excluding mp4 because I want convert it to mp4
            return new DirectoryInfo(directoryPath).GetFiles().Where(x => x.Extension != ".mp4");
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
