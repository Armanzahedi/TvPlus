using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TvPlus.Utility.Enums;

namespace TvPlus.Core.Models
{
    [Table("Center_People")]
    public class People : Center
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Gender  { get; set; }
        public string Biography { get; set; }
    }
}
