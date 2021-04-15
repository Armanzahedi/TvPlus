using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvPlus.Core.Models
{
    public class CenterType
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FarsiTitle { get; set; }

        public string Description { get; set; }

        public ICollection<Center> Centers { get; set; }
        public ICollection<RelationRule> RelationRules1 { get; set; }
        public ICollection<RelationRule> RelationRules2 { get; set; }
    }
}
