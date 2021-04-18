using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Core.Models
{
   public class Slider : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string Image { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
