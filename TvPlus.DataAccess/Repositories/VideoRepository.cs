using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IVideoRepository : IBaseRepository<Video>
    {
    }
    public class VideoRepository : BaseRepository<Video>, IVideoRepository
    {
        private readonly MyDbContext _context;
        public VideoRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
