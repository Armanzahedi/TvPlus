using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
    }
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly MyDbContext _context;
        public PostRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
