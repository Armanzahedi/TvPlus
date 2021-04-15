using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IVideoConvertRepository : IBaseRepository<VideoConvert>
    {
    }
    public class VideoConvertRepository : BaseRepository<VideoConvert>, IVideoConvertRepository
    {
        private readonly MyDbContext _context;
        public VideoConvertRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
