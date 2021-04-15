using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Utility.Enums;

namespace TvPlus.Infrastructure.Services
{
    public interface IVideoService : IVideoRepository
    {
        VideoConvert AddConvertedVideo(int videoId,int quality, string filePath);
        List<VideoConvert> GetVideoConverts(int videoId);
        VideoConvert DeleteVideoConvert(int videoId);
        Video AddVideo(int centerId, string path);
        Video GetByCenterId(int centerId);

    }
    public class VideoService : VideoRepository, IVideoService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepo;
        private readonly IVideoConvertRepository _videoConvertRepo;
        public VideoService(
            IMapper mapper,
            MyDbContext context,
            IVideoRepository videoRepo,
            IVideoConvertRepository videoConvertRepo) : base(context)
        {
            _mapper = mapper;
            _context = context;
            _videoRepo = videoRepo;
            _videoConvertRepo = videoConvertRepo;
        }

        public VideoConvert AddConvertedVideo(int videoId, int quality, string name)
        {
            var videoConvert = new VideoConvert
            {
                VideoId = videoId,
                VideoName = name,
                VideoQuality = quality
            };
            _videoConvertRepo.Add(videoConvert);
            return videoConvert;
        }

        public List<VideoConvert> GetVideoConverts(int videoId)
        {
            return _context.VideoConverts.Where(vc => vc.IsDeleted == false).ToList();
        }

        public VideoConvert DeleteVideoConvert(int Id)
        {
            var videoConvert = _context.VideoConverts.Find(Id);

            if (videoConvert != null)
            {
                videoConvert.IsDeleted = true;
                _videoConvertRepo.Update(videoConvert);
            }
            return videoConvert;
        }
        public Video AddVideo(int centerId, string name)
        {
            var video = new Video
            {
                CenterId = centerId,
                VideoName = name,
                ConversionStatus = ConversionStatus.InQueue,
                IsDeleted = false
            };
            base.Add(video);
            return video;
        }

        public Video GetByCenterId(int centerId)
        {
            return _context.Videos.FirstOrDefault(v => v.IsDeleted == false && v.CenterId == centerId);
        }
    }
}
