using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Utility.Enums;

namespace TvPlus.Core.Models
{
    public class Video : IBaseEntity
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
        public string VideoName { get; set; }
        public ConversionStatus ConversionStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<VideoConvert> VideoConverts { get; set; }
    }
}
