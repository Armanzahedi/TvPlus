using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Core.Models
{
   public class VideoConvert : IBaseEntity
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public int Height { get; set; }
        public int Duration { get; set; }
        public int ZStatus { get; set; }
        public Video Video { get; set; }
        public int VideoQuality { get; set; }
        public string VideoName { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
        public string ZErrors { get; set; }
    }
}
