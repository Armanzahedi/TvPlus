//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Linq.Expressions;
using System.Linq;

namespace TvPlus.Core.Models
{
    public class Member : IBaseEntity
    {
        public int Id { get; set; }
        public int CenterId1 { get; set; }
        public int CenterId2 { get; set; }
        public int? ParentId { get; set; }
        public int RelatedTypeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsArchive { get; set; }
        public bool IsDeleted { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public short? OrderNo { get; set; }
        public Center Center1 { get; set; }
        public Center Center2 { get; set; }
        public ICollection<Member> ChildMembers { get; set; }
        public Member ParentMember { get; set; }
        public RelationType MemberRelationType { get; set; }

    }
}
