using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;

namespace TvPlus.Infrastructure.Services
{
    public interface ISubscriptionPackageService : ISubscriptionPackageRepository
    {
    }
    public class SubscriptionPackageService : SubscriptionPackageRepository, ISubscriptionPackageService
    {
        public SubscriptionPackageService(MyDbContext context) : base(context)
        {
        }
    }
}
