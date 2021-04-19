using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace TvPlus.Core.Models
{
   public class AboutUs : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public ICollection<AboutUsSection> AboutUsSections { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
