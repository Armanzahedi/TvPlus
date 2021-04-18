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
        public bool IsTopTen { get; set; }
        public bool IsTrendTv { get; set; }
    }
}
