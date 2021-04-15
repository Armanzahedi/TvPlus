using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IImageRepository : IBaseRepository<Image>
    {
    }
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        private readonly MyDbContext _context;
        public ImageRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
