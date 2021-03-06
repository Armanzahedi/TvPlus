using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IRelationTypeRepository : IBaseRepository<RelationType>
    {
    }
    public class RelationTypeRepository : BaseRepository<RelationType>, IRelationTypeRepository
    {
        private readonly MyDbContext _context;
        public RelationTypeRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
