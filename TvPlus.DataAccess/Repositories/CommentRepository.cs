using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
    }
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly MyDbContext _context;
        public CommentRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
