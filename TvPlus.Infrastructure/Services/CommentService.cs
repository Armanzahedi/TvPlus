using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.ViewModels;

namespace TvPlus.Infrastructure.Services
{
    public interface ICommentService : ICommentRepository
    {
        List<CommentInfoViewModel> GetCenterVisibleComments(int centerId);
        IQueryable<Comment> GetCommentTableQuery(int? centerId = null);
    }
    public class CommentService : CommentRepository, ICommentService
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly MyDbContext _context;
        public CommentService(
            ICommentRepository CommentRepository, MyDbContext context) : base(context)
        {
            _CommentRepository = CommentRepository;
            _context = context;
        }

        public List<CommentInfoViewModel> GetCenterVisibleComments(int centerId)
        {
            var commentIds = base.GetDefaultQuery().Where(c => c.Show == true && c.CenterId == centerId)
                .Select(c => c.Id).ToList();

            return commentIds.Select(CreateCommentInfo).ToList();
        }

        public IQueryable<Comment> GetCommentTableQuery(int? centerId = null)
        {
            var query = _context.Comments.Where(c=>c.IsDeleted == false);
            if (centerId != null)
                query = query.Where(c => c.CenterId == centerId);
            return query;
        }

        #region Private
        private CommentInfoViewModel CreateCommentInfo(int commentId)
        {
            var comment = base.GetById(commentId);
            var writer = _context.Users.FirstOrDefault(u => u.Id == comment.UserId);
            var model = new CommentInfoViewModel
            {
                Id = commentId,
                Writer = $"{writer.FirstName} {writer.LastName}",
                AddedDate = comment.InsertDate,
                WriterImage = writer?.Avatar ?? "temp.png",
                Message = comment.Message
            };
            return model;
        }
        #endregion
    }
}
