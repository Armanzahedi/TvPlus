using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvPlus.Core.Models
{
    [Table("Center_Tags")]
    public class Tag : Center 
    {
        public int TagId { get; set; }
    }
}
