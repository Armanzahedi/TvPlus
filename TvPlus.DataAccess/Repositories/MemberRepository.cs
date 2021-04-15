using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
    }
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        private readonly MyDbContext _context;
        public MemberRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
