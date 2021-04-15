using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;

namespace TvPlus.Infrastructure.Services
{
    public interface IImageService : IImageRepository
    {
        Image GetByCenterId(int centerId);
    }

    public class ImageService : ImageRepository, IImageService
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public ImageService(
            IMapper mapper, MyDbContext context) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Image GetByCenterId(int centerId)
        {
            return _context.Images.FirstOrDefault(v => v.IsDeleted == false && v.CenterId == centerId);
        }
    }
}
