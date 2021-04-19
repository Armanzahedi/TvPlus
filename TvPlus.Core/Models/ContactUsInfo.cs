using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvPlus.Core.Models
{
    [Table("ContactUsInfo")]
   public class ContactUsInfo : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tel { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(100)]
        public string InsertUser { get; set; }
        [MaxLength(100)]
        public string UpdateUser { get; set; }

        public bool IsDeleted { get; set; }
    }
}
