using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;

namespace TvPlus.Infrastructure.Services
{
    public interface ICommentService : ICommentRepository
    {
        List<Comment> GetCenterVisibleComments(int centerId);
    }
    public class CommentService : CommentRepository, ICommentService
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IMapper _mapper;
        public CommentService(
            ICommentRepository CommentRepository, MyDbContext context) : base(context)
        {
            _CommentRepository = CommentRepository;
        }

        public List<Comment> GetCenterVisibleComments(int centerId)
        {
            return base.GetDefaultQuery().Where(c => c.Show == true && c.CenterId == centerId).ToList();
        }
    }
}
