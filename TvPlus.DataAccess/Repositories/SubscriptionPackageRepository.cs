using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface ISubscriptionPackageRepository : IBaseRepository<SubscriptionPackage>
    {
    }
    public class SubscriptionPackageRepository : BaseRepository<SubscriptionPackage>, ISubscriptionPackageRepository
    {
        private readonly MyDbContext _context;
        public SubscriptionPackageRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
