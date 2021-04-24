using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.Core.Models
{
    public class Comment : IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
        public bool Show { get; set; }
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
