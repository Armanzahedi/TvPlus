using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TvPlus.Core.Models
{
    [Table("Center_Posts")]
    public class Post : Center
    {
        public DateTime PublishDate { get; set; }
        public string Context { get; set; }
        public int ViewCount { get; set; }
        public bool IsSpecialOffer { get; set; }
        public int LikeCount { get; set; }
        public string ZStatus { get; set; }
        public string ZSeoTitle { get; set; }
        public int ZLength { get; set; }
        public int ZCommentLimit { get; set; }
        public int ZShowInVarzesh3 { get; set; }
        public string ZCategorySlug { get; set; }
        public int ZCommentRead { get; set; }
        public int ZCommentUnRead { get; set; }
        public int ZSocialShowInMain { get; set; }
    }
}
