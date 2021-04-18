using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly MyDbContext _context;
        public CategoryRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
