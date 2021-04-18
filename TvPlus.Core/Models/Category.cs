using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Core.Models
{
    public class Category : IBaseEntity
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<CenterCategory> CenterCategories { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public bool Show { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
