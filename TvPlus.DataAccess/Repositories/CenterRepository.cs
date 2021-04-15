using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface ICenterRepository : IBaseRepository<Center>
    {
    }
    public class CenterRepository : BaseRepository<Center>, ICenterRepository
    {
        private readonly MyDbContext _context;
        public CenterRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
