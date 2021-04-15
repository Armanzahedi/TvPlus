using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Utility.Enums;
using Xabe.FFmpeg;

namespace TvPlus.Infrastructure.Services
{
    public interface ICenterService : ICenterRepository
    {
        Center Save(Center entity);
    }
    public class CenterService : CenterRepository, ICenterService
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepo;
        public CenterService(
            IMapper mapper,
            MyDbContext context, IVideoRepository videoRepo) : base(context)
        {
            _mapper = mapper;
            _videoRepo = videoRepo;
        }
        public Center Save(Center entity)
        {
            return base.AddOrUpdate(entity);
        }

    }
}
