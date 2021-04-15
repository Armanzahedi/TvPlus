using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IPeopleRepository : IBaseRepository<People>
    {
    }
    public class PeopleRepository : BaseRepository<People>, IPeopleRepository
    {
        private readonly MyDbContext _context;
        public PeopleRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
