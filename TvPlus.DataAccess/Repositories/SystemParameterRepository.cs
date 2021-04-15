using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface ISystemParameterRepository : IBaseRepository<SystemParameter>
    {
    }
    public class SystemParameterRepository : BaseRepository<SystemParameter>, ISystemParameterRepository
    {
        private readonly MyDbContext _context;
        public SystemParameterRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
