using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace TvPlus.Infrastructure.ViewModels
{
    public class CommentInfoViewModel
    {
        public int Id { get; set; }
        public string Writer { get; set; }
        public string WriterImage { get; set; }
        public string Message { get; set; }
        public DateTime AddedDate { get; set; }
    }
    public class CommentTable
    {
        public int Id { get; set; }
        public string Writer { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Show { get; set; }
    }

    public class EditCommentViewModel
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public string Message { get; set; }
    }
    public class EditCommentValidator : AbstractValidator<EditCommentViewModel>
    {

        public EditCommentValidator()
        {
            RuleFor(sp => sp.Message).NotEmpty().WithName("نظر");
        }
    }

    public class SubmitCommentViewModel
    {
        public int CenterId { get; set; }
        public string Message { get; set; }
    }
}
