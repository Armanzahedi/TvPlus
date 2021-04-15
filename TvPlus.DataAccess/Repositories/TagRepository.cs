using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
    }
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        private readonly MyDbContext _context;
        public TagRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
