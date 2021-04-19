using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IAboutUsRepository : IBaseRepository<AboutUs>
    {
    }
    public class AboutUsRepository : BaseRepository<AboutUs>, IAboutUsRepository
    {
        private readonly MyDbContext _context;
        public AboutUsRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
