using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    {
    }
    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository
    {
        private readonly MyDbContext _context;
        public DiscountRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
