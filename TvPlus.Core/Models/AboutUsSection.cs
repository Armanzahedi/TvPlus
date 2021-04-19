using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Core.Models
{
    public class AboutUsSection : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AboutUsId { get; set; }
        public AboutUs AboutUs { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
