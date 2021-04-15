using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvPlus.Core.Models
{
    [Table("Center_Specials")]
    public class SpecialEvent : Center
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
