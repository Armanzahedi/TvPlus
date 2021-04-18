using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface ICenterCategoryRepository : IBaseRepository<CenterCategory>
    {
    }
    public class CenterCategoryRepository : BaseRepository<CenterCategory>, ICenterCategoryRepository
    {
        private readonly MyDbContext _context;
        public CenterCategoryRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
