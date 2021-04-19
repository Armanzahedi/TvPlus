using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IAboutUsSectionsRepository : IBaseRepository<AboutUsSection>
    {
    }
    public class AboutUsSectionsRepository : BaseRepository<AboutUsSection>, IAboutUsSectionsRepository
    {
        private readonly MyDbContext _context;
        public AboutUsSectionsRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
