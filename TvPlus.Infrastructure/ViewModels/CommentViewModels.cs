using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
