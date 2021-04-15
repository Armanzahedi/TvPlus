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
    public interface IRelationRuleRepository : IBaseRepository<RelationRule>
    {
    }
    public class RelationRuleRepository : BaseRepository<RelationRule>, IRelationRuleRepository
    {
        private readonly MyDbContext _context;
        public RelationRuleRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
