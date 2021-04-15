using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;

namespace TvPlus.Core.Models
{
    public class RelationType : IBaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FarsiTitle { get; set; }

        public string Description { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<RelationRule> RelationRules { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}