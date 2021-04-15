using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvPlus.Core.Models
{
    public class RelationRule : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }


        public int CenterTypeId1 { get; set; }
        public CenterType FirstCenter { get; set; }
        public int CenterTypeId2 { get; set; }
        public CenterType SecondCenter { get; set; }

        public int RelationTypeId { get; set; }

        public byte OperationType { get; set; }

        public byte Cardinality { get; set; }

        public RelationType RelationType { get; set; }
    }
}
