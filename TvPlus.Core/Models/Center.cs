using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Core.Models
{
    public class Center : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public Guid UniqueId { get; set; }
        public byte CenterTypeId { get; set; }
        public string Description { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CenterCategory> CenterCategories { get; set; }
        public ICollection<Member> Members1 { get; set; }
        public ICollection<Member> Members2 { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
