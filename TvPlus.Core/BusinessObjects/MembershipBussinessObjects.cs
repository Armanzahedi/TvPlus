using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Core.BusinessObjects
{
	public class MembershipEntity
    {
        public int MemberId { get; set; }
        public int SelfCenterId { get; set; }
        public string SelfCenterTitle { get; set; }
        public int SelfCenterIndex { get; set; }
        public int CenterId { get; set; }
        public string CenterTitle { get; set; }
        public int RelationTypeId { get; set; }
        public string RelationTypeTitle { get; set; }
        public string RelationTypeFarsiTitle { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsArchive { get; set; }
        public string AdditionalInfo { get; set; }
        public short? OrderNo { get; set; }
    }

    public class MembershipTwoEntity
    {
        public int MemberId { get; set; }
        public int CenterId1 { get; set; }
        public string CenterTitle1 { get; set; }
        public int CenterId2 { get; set; }
        public string CenterTitle2 { get; set; }
        public int RelationTypeId { get; set; }
        public string RelationTypeTitle { get; set; }
        public string RelationTypeFarsiTitle { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsArchive { get; set; }
        public string AdditionalInfo { get; set; }
        public short? OrderNo { get; set; }
    }
}
