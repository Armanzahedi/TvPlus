using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Core.Models
{
    public class CenterCategory : IBaseEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
