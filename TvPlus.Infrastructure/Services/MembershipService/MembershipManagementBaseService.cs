using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Core.BusinessObjects;
using TvPlus.Core.Models;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.Services;
using TvPlus.Utility.Enums;

namespace TvPlus.Services.Membership
{
    public interface IMembershipManagementBaseService
    {
        RelationTypes RelationTypes { get; set; }
        bool PreValidateMembership(Center center1, Center center2, RelationTypes RelationTypes, DateTime? fromDate, DateTime? toDate, out string message);
        bool SwapSidesIfNecessary(ref Center center1, ref Center center2, RelationTypes RelationTypes);
        bool ValidateRelationRule(int centerTypeId1, int centerTypeId2, RelationTypes RelationTypes);
        bool ValidateMembership(Member currentMember, Center center1, Center center2, RelationTypes RelationTypes, out string message);
        bool ValidateCardinality(Member currentMember, Center center1, Center center2, RelationRule rule, out string message);
        bool ValidateMembershipDuplicity(Center center1, Center center2, RelationTypes RelationTypes, DateTime? fromDate = null, DateTime? toDate = null, bool isInCreateMode = true);
        RelationRule GetRelationshipRule(int centerTypeId1, int centerTypeId2, RelationTypes RelationTypes);
        RelationRule GetRelationshipRule(RelationTypes RelationTypes);
        Member RegisterMembership(Center center1, Center center2, DateTime? fromDate, DateTime? toDate, out string message, int? memberId = null, RelationTypes RelationTypes = RelationTypes.None, string additionalInfo = null);
        bool ArchiveMembership(Member member, DateTime? toDate, out string message);
        bool ArchiveMembership(int memberId, DateTime? toDate, out string message);
        bool UnArchiveMembership(Member member, out string message);
        bool DeleteMembership(Member member, DateTime? toDate, out string message);
        bool DeleteMembership(int memberId, DateTime? toDate, out string message);
        List<Member> GetSelfMemberships(Center center, RelationTypes RelationTypes, bool? isArchive = null);
        List<Member> GetSelfMemberships(RelationTypes RelationTypes, bool? isArchive = null);
        List<MembershipEntity> GetMemberships(int centerId, bool? isArchive, bool includeAdditionalInfo);
        List<MembershipTwoEntity> GetMemberships(RelationTypes RelationTypes, bool? isArchive, bool includeAdditionalInfo);
        List<MembershipEntity> GetMemberships(int centerId, RelationTypes RelationTypes, bool? isArchive, bool includeAdditionalInfo);
        List<MembershipTwoEntity> GetMemberships(int centerId1, int centerId2, RelationTypes RelationTypes, bool? isArchive, bool includeAdditionalInfo);
        IQueryable<MembershipTwoEntity> GetQueryableMemberships(int centerId1, int centerId2, RelationTypes RelationTypes, bool? isArchive, bool includeAdditionalInfo);
        IQueryable<MembershipEntity> GetQueryableMemberships(int centerId, RelationTypes RelationTypes, bool? isArchive, bool includeAdditionalInfo);
        IQueryable<MembershipEntity> GetQueryableMemberships(int centerId, bool? isArchive, bool includeAdditionalInfo);
        IQueryable<MembershipEntity> GetQueryableMemberships(List<int> centerIds, bool? isArchive, bool includeAdditionalInfo);
        IQueryable<MembershipTwoEntity> GetQueryableMemberships(RelationTypes RelationTypes, bool? isArchive, bool includeAdditionalInfo);
    }

    public class MembershipManagementBaseService : IMembershipManagementBaseService
    {
        #region Fields & Properties
        private readonly IMemberService _memberService;
        private readonly ICenterService _centerService;
        private readonly IRelationTypeService _relationTypeService;
        private readonly IRelationRuleService _relationRuleService;

        public MembershipManagementBaseService(IMemberService memberService, ICenterService centerService, IRelationTypeService relationTypeService, IRelationRuleService relationRuleService)
        {
            _memberService = memberService;
            _centerService = centerService;
            _relationTypeService = relationTypeService;
            _relationRuleService = relationRuleService;
        }

        //public MembershipManagementBaseService()
        //{
        //    _memberService = new MemberService();
        //    _centerService = new CenterService();
        //    _relationTypeService = new RelationTypeService();
        //}

        public RelationTypes RelationTypes { get; set; }
        #endregion

        #region Base Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="center1"></param>
        /// <param name="center2"></param>
        /// <param name="relationType"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual bool PreValidateMembership(Center center1, Center center2, RelationTypes relationType, DateTime? fromDate, DateTime? toDate, out string message)
        {
            relationType = GetServiceRelationType(relationType);
            message = "";
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="center1"></param>
        /// <param name="center2"></param>
        /// <param name="relationType"></param>
        /// <returns></returns>
        public virtual bool SwapSidesIfNecessary(ref Center center1, ref Center center2, RelationTypes relationType)
        {
            var rule = GetRelationshipRule(relationType);
            if (rule == null)
                return false;

            if (rule.CenterTypeId1 == center2.CenterTypeId &&
                rule.CenterTypeId2 == center1.CenterTypeId &&
                rule.CenterTypeId1 != rule.CenterTypeId2)
            {
                var temp = center1;
                center1 = center2;
                center2 = temp;
                return true;
            }
            else if (!(rule.CenterTypeId1 == center1.CenterTypeId &&
                      rule.CenterTypeId2 == center2.CenterTypeId))
                return false;

            return false;
        }

        /// <summary>
        /// Validates the relating a center type to another
        /// </summary>
        /// <param name="centerTypeId1">First Center Type</param>
        /// <param name="centerTypeId2">Second Center Type</param>
        /// <param name="relationType">The relation type between center types</param>
        /// <returns>A bool value that indicates whether the membership is valid or not.</returns>
        public virtual bool ValidateRelationRule(int centerTypeId1, int centerTypeId2, RelationTypes relationType)
        {
            return _relationRuleService.GetDefaultQuery().Any(p => p.RelationTypeId == (int)relationType &&
                          ((p.CenterTypeId1 == centerTypeId1 && p.CenterTypeId2 == centerTypeId2) ||
                          ((p.CenterTypeId1 == centerTypeId2 && p.CenterTypeId2 == centerTypeId1))));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentMember"></param>
        /// <param name="center1"></param>
        /// <param name="center2"></param>
        /// <param name="relationType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual bool ValidateMembership(Member currentMember, Center center1, Center center2, RelationTypes relationType, out string message)
        {
            message = "";
            var rule = GetRelationshipRule(center1.CenterTypeId, center2.CenterTypeId, relationType);
            if (rule == null)
            {
                message = "Invalid membership.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentMember"></param>
        /// <param name="center1"></param>
        /// <param name="center2"></param>
        /// <param name="rule"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual bool ValidateCardinality(Member currentMember, Center center1, Center center2, RelationRule rule, out string message)
        {
            message = "";
            if (center1.Id <= 0 && center2.Id <= 0)
                return true;

            if (rule.Cardinality == (int)Cardinalities.Peer2Peer)
            {
                if (currentMember != null && currentMember.Id != 0)
                {
                    if ((center1.Id > 0 && GetMemberships(center1.Id, (RelationTypes)rule.RelationTypeId, false, false).Any(p => p.MemberId != currentMember.Id)) ||
                        (center2.Id > 0 && GetMemberships(center2.Id, (RelationTypes)rule.RelationTypeId, false, false).Any(p => p.MemberId != currentMember.Id)))
                    {
                        message = "1:1 relationships cannot have more than 1 endpoints on neither of entities.";
                        return false;
                    }
                }
                else
                {
                    if ((center1.Id > 0 && GetMemberships(center1.Id, (RelationTypes)rule.RelationTypeId, false, false).Any()) ||
                        (center2.Id > 0 && GetMemberships(center2.Id, (RelationTypes)rule.RelationTypeId, false, false).Any()))
                    {
                        message = "1:1 relationships cannot have more than 1 endpoints on neither of entities.";
                        return false;
                    }
                }
            }
            else if (rule.Cardinality == (int)Cardinalities.One2Many)
            {
                if (currentMember != null && currentMember.Id != 0)
                {
                    if ((center2.Id > 0 && GetSelfMemberships(center2, (RelationTypes)rule.RelationTypeId, false).Any(p => p.Id != currentMember.Id && p.CenterId2 == center2.Id)))
                    {
                        message = "1:N relationships cannot have more than 1 endpoints on the second entity.";
                        return false;
                    }
                }
                else
                {
                    if ((center2.Id > 0 && GetSelfMemberships(center2, (RelationTypes)rule.RelationTypeId).Any(p => p.CenterId2 == center2.Id)))
                    {
                        message = "1:N relationships cannot have more than 1 endpoints on the second entity.";
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="center1"></param>
        /// <param name="center2"></param>
        /// <param name="relationType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual bool ValidateMembershipDuplicity(Center center1, Center center2, RelationTypes relationType, DateTime? fromDate = null, DateTime? toDate = null, bool isInCreateMode = true)
        {
            var memberships = GetMemberships(center1.Id, relationType, false, false);

            if (isInCreateMode)
            {
                if (memberships.Any(p => p.CenterId == center2.Id))
                    return false;
            }
            else
            {
                if (memberships.Any(p => p.CenterId == center2.Id && p.FromDate == fromDate && p.ToDate == toDate))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Get the relationship rules for a 2 center types with a specific relation type.
        /// </summary>
        /// <param name="centerTypeId1">First Center Type</param>
        /// <param name="centerTypeId2">Second Center Type</param>
        /// <param name="relationType">The relation type between center types</param>
        /// <returns>The relation rule of the given membership info</returns>
        public virtual RelationRule GetRelationshipRule(int centerTypeId1, int centerTypeId2, RelationTypes relationType)
        {
            return _relationRuleService.GetDefaultQuery()
                .FirstOrDefault(p =>
                    p.RelationTypeId == (int)relationType &&
                    ((p.CenterTypeId1 == centerTypeId1 && p.CenterTypeId2 == centerTypeId2) ||
                    ((p.CenterTypeId1 == centerTypeId2 && p.CenterTypeId2 == centerTypeId1))));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relationType"></param>
        /// <returns></returns>
        public virtual RelationRule GetRelationshipRule(RelationTypes relationType)
        {
            return _relationRuleService
                .GetDefaultQuery()
                .FirstOrDefault(p => p.RelationTypeId == (int)relationType);
        }

        /// <summary>
        /// Register membership (create a new member and return it, also if center1 and center2 have keies insert a new record into members table)
        /// </summary>
        /// <param name="center1"></param>
        /// <param name="center2"></param>
        /// <param name="relationType"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        private Member CreateMembership(Center center1, Center center2, RelationTypes relationType, DateTime? fromDate, DateTime? toDate, out string message, string additionalInfo)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            SwapSidesIfNecessary(ref center1, ref center2, relationType);

            if (!PreValidateMembership(center1, center2, relationType, null, null, out message))
                return null;

            var rule = GetRelationshipRule(center1.CenterTypeId, center2.CenterTypeId, relationType);

            if (rule == null)
            {
                message = "Invalid membership.";
                return null;
            }

            if (!ValidateMembership(null, center1, center2, relationType, out message))
                return null;

            if (!ValidateCardinality(null, center1, center2, rule, out message))
                return null;

            if (!ValidateMembershipDuplicity(center1, center2, relationType, fromDate, toDate, false))
            {
                message = "Membership duplicity detected.";
                return null;
            }

            var centerService = _centerService;
            if (center1.Id == 0)
                centerService.Save(center1);
            if (center2.Id == 0)
                centerService.Save(center2);

            var result = new Member
            {
                CenterId1 = center1.Id,
                CenterId2 = center2.Id,
                RelatedTypeId = (int)relationType,
                FromDate = ((fromDate ?? DateTime.MinValue) > DateTime.MinValue) ? fromDate : DateTime.Now,
                ToDate = (toDate ?? DateTime.MinValue) > DateTime.MinValue ? toDate : null,
                IsArchive = false,
                IsDeleted = false,
                ParentId = null,
                AdditionalInfo = additionalInfo
            };

            memberService.Save(result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="center1"></param>
        /// <param name="center2"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        private Member UpdateMembership(Center center1, Center center2, RelationTypes relationType, DateTime? fromDate, DateTime? toDate, int memberId, out string message, string additionalInfo)
        {
            message = "";
            //var  = new IField[0];
            var memberService = _memberService;
            SwapSidesIfNecessary(ref center1, ref center2, relationType);

            if (!PreValidateMembership(center1, center2, relationType, null, null, out message))
                return null;

            var rule = GetRelationshipRule(center1.CenterTypeId, center2.CenterTypeId, relationType);

            if (rule == null)
            {
                message = "Invalid membership.";
                return null;
            }

            var parentMember = memberService
                .GetDefaultQuery()
                .FirstOrDefault(p => p.Id == memberId);

            if (parentMember == null)
            {
                message = "The parent member cannot be null in update mode.";
                return null;
            }

            if (!ValidateMembership(parentMember, center1, center2, relationType, out message))
                return null;

            //چک کردن کاردینالیتی برای مود یک به یک گیر داشت برای همین کامنت شد
            //if (!ValidateCardinality(parentMember, center1, center2, rule, out message))
            //    return null;

            if (!ValidateMembershipDuplicity(center1, center2, relationType, fromDate, toDate, false))
            {
                message = "Membership duplicity detected.";
                return null;
            }

            var centerService = _centerService;
            if (center1.Id == 0)
                centerService.Save(center1);
            if (center2.Id != 0)
                centerService.Save(center2);

            var result = new Member
            {
                CenterId1 = center1.Id,
                CenterId2 = center2.Id,
                RelatedTypeId = (int)relationType,
                FromDate = ((fromDate ?? DateTime.MinValue) > DateTime.MinValue) ? fromDate : DateTime.Now,
                ToDate = (toDate ?? DateTime.MinValue) > DateTime.MinValue ? toDate : null,
                IsArchive = false,
                IsDeleted = false,
                ParentId = null,
                AdditionalInfo = additionalInfo
            };

            if (rule.OperationType == (int)OperationTypes.Historical)
            {
                if (parentMember != null)
                {
                    result.ParentId = parentMember.Id;
                    parentMember.IsArchive = true;
                    parentMember.ToDate = DateTime.Now;
                }
            }
            else
            {
                if (parentMember != null)
                {
                    parentMember.IsArchive = true;
                    parentMember.ToDate = DateTime.Now;
                }
            }

            if (parentMember != null)
                memberService.Save(parentMember);

            memberService.Save(result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="center1"></param>
        /// <param name="center2"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="message"></param>
        /// <param name="memberId"></param>
        /// <param name="relationType"></param>
        /// <returns></returns>
        public virtual Member RegisterMembership(Center center1, Center center2, DateTime? fromDate, DateTime? toDate, out string message, int? memberId = null, RelationTypes relationType = RelationTypes.None, string additionalInfo = null)
        {
            relationType = GetServiceRelationType(relationType);
            if ((memberId ?? 0) > 0)
                return UpdateMembership(center1, center2, relationType, fromDate, toDate, memberId.Value, out message, additionalInfo);
            else
                return CreateMembership(center1, center2, relationType, fromDate, toDate, out message, additionalInfo);
        }

        public virtual List<Member> GetSelfMemberships(Center center, RelationTypes relationType, bool? isArchive = null)
        {
            //var  = new IField[0];
            var centerTypeId = _centerService
                .GetDefaultQuery()
                .Where(p => p.Id == center.Id)
                .Select(p => p.CenterTypeId)
                .FirstOrDefault();

            var relationRule = _relationRuleService
                .GetDefaultQuery()
                .Where(p => p.RelationTypeId == (int)relationType)
                .FirstOrDefault();

            var memberService = _memberService;

            if (relationRule.CenterTypeId1 == centerTypeId && relationRule.CenterTypeId2 == centerTypeId)
                return memberService
                    .GetDefaultQuery()
                    .Where(p => p.RelatedTypeId == (int)relationType && (p.CenterId1 == center.Id || p.CenterId2 == center.Id))
                    .Where(p => isArchive.HasValue && p.IsArchive == isArchive.Value)
                    .ToList();
            else if (relationRule.CenterTypeId1 == centerTypeId)
                return memberService
                    .GetDefaultQuery()
                    .Where(p => p.RelatedTypeId == (int)relationType && p.CenterId1 == center.Id)
                    .Where(p => isArchive.HasValue && p.IsArchive == isArchive.Value)
                    .ToList();
            else if (relationRule.CenterTypeId2 == centerTypeId)
                return memberService
                    .GetDefaultQuery()
                    .Where(p => p.RelatedTypeId == (int)relationType && (p.CenterId1 == center.Id || p.CenterId2 == center.Id))
                    .Where(p => isArchive.HasValue && p.IsArchive == isArchive.Value)
                    .ToList();
            else
                return new List<Member>();
        }

        public virtual List<Member> GetSelfMemberships(RelationTypes relationType, bool? isArchive = null)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            return memberService
                .GetDefaultQuery()
                .Where(p => p.RelatedTypeId == (int)relationType)
                .Where(p => isArchive.HasValue && p.IsArchive == isArchive.Value)
                .ToList();
        }

        public bool ArchiveMembership(Member member, DateTime? toDate, out string message)
        {
            message = "";
            var memberService = _memberService;
            member.IsArchive = true;
            member.ToDate = toDate;
            memberService.Save(member);
            return true;
        }

        public bool ArchiveMembership(int memberId, DateTime? toDate, out string message)
        {
            message = "";
            var memberService = _memberService;
            var member = memberService
                .GetDefaultQuery()
                .FirstOrDefault(p => p.Id == memberId);
            member.IsArchive = true;
            member.ToDate = toDate;
            memberService.Save(member);
            return true;
        }

        public bool UnArchiveMembership(Member member, out string message)
        {
            message = "";
            var memberService = _memberService;
            member.IsArchive = false;
            member.ToDate = null;
            memberService.Save(member);
            return true;
        }

        public virtual bool DeleteMembership(Member member, DateTime? toDate, out string message)
        {
            message = "";
            var memberService = _memberService;
            member.IsDeleted = true;
            memberService.Save(member);
            return true;
        }

        public virtual bool DeleteMembership(int memberId, DateTime? toDate, out string message)
        {
            message = "";
            var memberService = _memberService;
            var member = memberService
                .GetDefaultQuery()
                .FirstOrDefault(p => p.Id == memberId);
            member.IsDeleted = true;
            memberService.Save(member);
            return true;
        }

        public virtual List<MembershipTwoEntity> GetMemberships(int centerId1, int centerId2, RelationTypes relationType, bool? isArchive, bool includeAdditionalInfo)
        {
            //var  = new IField[0];
            var centerService = _centerService;
            var relationTypeService = _relationTypeService;
            var relationRuleService = _relationRuleService;
            //centerService.MakeFriend(memberService);
            //relationTypeService.MakeFriend(centerService);

            var result = from m in _memberService.GetDefaultQuery()
                         join c1 in centerService.GetDefaultQuery() on m.CenterId1 equals c1.Id
                         join c2 in centerService.GetDefaultQuery() on m.CenterId2 equals c2.Id
                         join rt in relationTypeService.GetDefaultQuery() on m.RelatedTypeId equals rt.Id
                         where (m.RelatedTypeId == (int)relationType || (int)relationType == (int)RelationTypes.None) &&
                               ((c1.Id == centerId1 && c2.Id == centerId2) ||
                                (c1.Id == centerId2 && c2.Id == centerId1)) &&
                               ((isArchive.HasValue && m.IsArchive == isArchive.Value) || !isArchive.HasValue)
                         select new MembershipTwoEntity
                         {
                             MemberId = m.Id,
                             CenterId1 = c1.Id,
                             CenterTitle1 = c1.Title,
                             CenterId2 = c2.Id,
                             CenterTitle2 = c2.Title,
                             FromDate = m.FromDate,
                             ToDate = m.ToDate,
                             IsArchive = m.IsArchive,
                             RelationTypeId = rt.Id,
                             RelationTypeTitle = rt.Title,
                             RelationTypeFarsiTitle = rt.FarsiTitle,
                             AdditionalInfo = includeAdditionalInfo ? m.AdditionalInfo : null,
                             OrderNo = m.OrderNo
                         };

            return result.ToList();
        }

        public virtual List<MembershipEntity> GetMemberships(int centerId, RelationTypes relationType, bool? isArchive, bool includeAdditionalInfo)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            var centerService = _centerService;
            var relationTypeService = _relationTypeService;
            var relationRuleService = _relationRuleService;
            //centerService.MakeFriend(memberService);
            //relationTypeService.MakeFriend(memberService);
            //relationRuleService.MakeFriend(relationTypeService);

            var result = from m in memberService.GetDefaultQuery()
                         join c1 in centerService.GetDefaultQuery() on m.CenterId1 equals c1.Id
                         join c2 in centerService.GetDefaultQuery() on m.CenterId2 equals c2.Id
                         join rt in relationTypeService.GetDefaultQuery() on m.RelatedTypeId equals rt.Id
                         join rr in relationRuleService.GetDefaultQuery() on rt.Id equals rr.RelationTypeId
                         where ((c1.Id == centerId && c1.CenterTypeId == rr.CenterTypeId1) ||
                                (c2.Id == centerId && c2.CenterTypeId == rr.CenterTypeId2)) &&
                               (rt.Id == (int)relationType || (int)relationType == (int)RelationTypes.None) &&
                               ((isArchive.HasValue && m.IsArchive == isArchive.Value) || !isArchive.HasValue)
                         select new MembershipEntity
                         {
                             MemberId = m.Id,
                             SelfCenterId = c1.Id == centerId ? c1.Id : c2.Id,
                             SelfCenterTitle = c1.Id == centerId ? c1.Title : c2.Title,
                             SelfCenterIndex = c1.Id == centerId ? 1 : 2,
                             CenterId = c1.Id == centerId ? c2.Id : c1.Id,
                             CenterTitle = c1.Id == centerId ? c2.Title : c1.Title,
                             FromDate = m.FromDate,
                             ToDate = m.ToDate,
                             IsArchive = m.IsArchive,
                             RelationTypeId = (int)relationType,
                             RelationTypeTitle = rt.Title,
                             RelationTypeFarsiTitle = rt.FarsiTitle,
                             AdditionalInfo = includeAdditionalInfo ? m.AdditionalInfo : null,
                             OrderNo = m.OrderNo
                         };

            return result.ToList();
        }

        public virtual List<MembershipEntity> GetMemberships(int centerId, bool? isArchive, bool includeAdditionalInfo)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            var centerService = _centerService;
            var relationTypeService = _relationTypeService;
            var relationRuleService = _relationRuleService;
            //centerService.MakeFriend(memberService);
            //relationTypeService.MakeFriend(centerService);

            var result = from m in memberService.GetDefaultQuery()
                         join c1 in centerService.GetDefaultQuery() on m.CenterId1 equals c1.Id
                         join c2 in centerService.GetDefaultQuery() on m.CenterId2 equals c2.Id
                         join rt in relationTypeService.GetDefaultQuery() on m.RelatedTypeId equals rt.Id
                         where (c1.Id == centerId || c2.Id == centerId) &&
                               ((isArchive.HasValue && m.IsArchive == isArchive.Value) || !isArchive.HasValue)
                         select new MembershipEntity
                         {
                             MemberId = m.Id,
                             SelfCenterId = centerId,
                             SelfCenterTitle = c1.Id == centerId ? c1.Title : c2.Title,
                             SelfCenterIndex = c1.Id == centerId ? 1 : 2,
                             CenterId = c1.Id == centerId ? c2.Id : c1.Id,
                             CenterTitle = c1.Id == centerId ? c2.Title : c1.Title,
                             FromDate = m.FromDate,
                             ToDate = m.ToDate,
                             IsArchive = m.IsArchive,
                             RelationTypeId = rt.Id,
                             RelationTypeTitle = rt.Title,
                             RelationTypeFarsiTitle = rt.FarsiTitle,
                             AdditionalInfo = includeAdditionalInfo ? m.AdditionalInfo : null,
                             OrderNo = m.OrderNo
                         };

            return result.ToList();
        }

        public virtual List<MembershipTwoEntity> GetMemberships(RelationTypes relationType, bool? isArchive, bool includeAdditionalInfo)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            var centerService = _centerService;
            var relationTypeService = _relationTypeService;
            var relationRuleService = _relationRuleService;
            //centerService.MakeFriend(memberService);
            //relationTypeService.MakeFriend(centerService);

            var result = from m in memberService.GetDefaultQuery()
                         join c1 in centerService.GetDefaultQuery() on m.CenterId1 equals c1.Id
                         join c2 in centerService.GetDefaultQuery() on m.CenterId2 equals c2.Id
                         join rt in relationTypeService.GetDefaultQuery() on m.RelatedTypeId equals rt.Id
                         where (m.RelatedTypeId == (int)relationType || (int)relationType == (int)RelationTypes.None) &&
                               ((isArchive.HasValue && m.IsArchive == isArchive.Value) || !isArchive.HasValue)
                         select new MembershipTwoEntity
                         {
                             MemberId = m.Id,
                             CenterId1 = c1.Id,
                             CenterTitle1 = c1.Title,
                             CenterId2 = c2.Id,
                             CenterTitle2 = c2.Title,
                             FromDate = m.FromDate,
                             ToDate = m.ToDate,
                             IsArchive = m.IsArchive,
                             RelationTypeId = rt.Id,
                             RelationTypeTitle = rt.Title,
                             RelationTypeFarsiTitle = rt.FarsiTitle,
                             AdditionalInfo = includeAdditionalInfo ? m.AdditionalInfo : null,
                             OrderNo = m.OrderNo
                         };

            return result.ToList();
        }

        public virtual IQueryable<MembershipTwoEntity> GetQueryableMemberships(int centerId1, int centerId2, RelationTypes relationType, bool? isArchive, bool includeAdditionalInfo)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            var centerService = _centerService;
            var relationTypeService = _relationTypeService;
            var relationRuleService = _relationRuleService;
            //centerService.MakeFriend(memberService);
            //relationTypeService.MakeFriend(centerService);

            //if (service != null)
            //    service.MakeFriend(memberService);

            var result = from m in memberService.GetDefaultQuery()
                         join c1 in centerService.GetDefaultQuery() on m.CenterId1 equals c1.Id
                         join c2 in centerService.GetDefaultQuery() on m.CenterId2 equals c2.Id
                         join rt in relationTypeService.GetDefaultQuery() on m.RelatedTypeId equals rt.Id
                         where (m.RelatedTypeId == (int)relationType || (int)relationType == (int)RelationTypes.None) &&
                               c1.Id == centerId1 && c2.Id == centerId2 &&
                               ((isArchive.HasValue && m.IsArchive == isArchive.Value) || !isArchive.HasValue)
                         select new MembershipTwoEntity
                         {
                             MemberId = m.Id,
                             CenterId1 = c1.Id,
                             CenterTitle1 = c1.Title,
                             CenterId2 = c2.Id,
                             CenterTitle2 = c2.Title,
                             FromDate = m.FromDate,
                             ToDate = m.ToDate,
                             IsArchive = m.IsArchive,
                             RelationTypeId = rt.Id,
                             RelationTypeTitle = rt.Title,
                             RelationTypeFarsiTitle = rt.FarsiTitle,
                             AdditionalInfo = includeAdditionalInfo ? m.AdditionalInfo : null,
                             OrderNo = m.OrderNo
                         };

            return result.AsQueryable();
        }

        public virtual IQueryable<MembershipEntity> GetQueryableMemberships(int centerId, RelationTypes relationType, bool? isArchive, bool includeAdditionalInfo)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            var centerService = _centerService;
            var relationTypeService = _relationTypeService;
            var relationRuleService = _relationRuleService;
            //centerService.MakeFriend(memberService);
            //relationTypeService.MakeFriend(memberService);
            //relationRuleService.MakeFriend(relationTypeService);

            //if (service != null)
            //    service.MakeFriend(memberService);

            var result = from m in memberService.GetDefaultQuery()
                         join c1 in centerService.GetDefaultQuery() on m.CenterId1 equals c1.Id
                         join c2 in centerService.GetDefaultQuery() on m.CenterId2 equals c2.Id
                         join rt in relationTypeService.GetDefaultQuery() on m.RelatedTypeId equals rt.Id
                         join rr in relationRuleService.GetDefaultQuery() on rt.Id equals rr.RelationTypeId
                         where ((c1.Id == centerId && c1.CenterTypeId == rr.CenterTypeId1) ||
                                (c2.Id == centerId && c2.CenterTypeId == rr.CenterTypeId2)) &&
                               (rt.Id == (int)relationType || (int)relationType == (int)RelationTypes.None) &&
                               ((isArchive.HasValue && m.IsArchive == isArchive.Value) || !isArchive.HasValue)
                         select new MembershipEntity
                         {
                             MemberId = m.Id,
                             SelfCenterId = c1.Id == centerId ? c1.Id : c2.Id,
                             SelfCenterTitle = c1.Id == centerId ? c1.Title : c2.Title,
                             SelfCenterIndex = c1.Id == centerId ? 1 : 2,
                             CenterId = c1.Id == centerId ? c2.Id : c1.Id,
                             CenterTitle = c1.Id == centerId ? c2.Title : c1.Title,
                             FromDate = m.FromDate,
                             ToDate = m.ToDate,
                             IsArchive = m.IsArchive,
                             RelationTypeId = (int)relationType,
                             RelationTypeTitle = rt.Title,
                             RelationTypeFarsiTitle = rt.FarsiTitle,
                             AdditionalInfo = includeAdditionalInfo ? m.AdditionalInfo : null,
                             OrderNo = m.OrderNo
                         };

            return result.AsQueryable();
        }

        public virtual IQueryable<MembershipEntity> GetQueryableMemberships(int centerId, bool? isArchive, bool includeAdditionalInfo)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            var centerService = _centerService;
            var relationTypeService = _relationTypeService;
            var relationRuleService = _relationRuleService;
            //centerService.MakeFriend(memberService);
            //relationTypeService.MakeFriend(memberService);
            //relationRuleService.MakeFriend(relationTypeService);

            //if (service != null)
            //    service.MakeFriend(memberService);

            var result = from m in memberService.GetDefaultQuery()
                         join c1 in centerService.GetDefaultQuery() on m.CenterId1 equals c1.Id
                         join c2 in centerService.GetDefaultQuery() on m.CenterId2 equals c2.Id
                         join rt in relationTypeService.GetDefaultQuery() on m.RelatedTypeId equals rt.Id
                         join rr in relationRuleService.GetDefaultQuery() on rt.Id equals rr.RelationTypeId
                         where ((c1.Id == centerId && c1.CenterTypeId == rr.CenterTypeId1) ||
                                (c2.Id == centerId && c2.CenterTypeId == rr.CenterTypeId2)) &&
                                ((isArchive.HasValue && m.IsArchive == isArchive.Value) || !isArchive.HasValue)
                         select new MembershipEntity
                         {
                             MemberId = m.Id,
                             SelfCenterId = c1.Id == centerId ? c1.Id : c2.Id,
                             SelfCenterTitle = c1.Id == centerId ? c1.Title : c2.Title,
                             SelfCenterIndex = c1.Id == centerId ? 1 : 2,
                             CenterId = c1.Id == centerId ? c2.Id : c1.Id,
                             CenterTitle = c1.Id == centerId ? c2.Title : c1.Title,
                             FromDate = m.FromDate,
                             ToDate = m.ToDate,
                             IsArchive = m.IsArchive,
                             RelationTypeId = m.RelatedTypeId,
                             RelationTypeTitle = rt.Title,
                             RelationTypeFarsiTitle = rt.FarsiTitle,
                             AdditionalInfo = includeAdditionalInfo ? m.AdditionalInfo : null,
                             OrderNo = m.OrderNo
                         };

            return result.AsQueryable();
        }

        public virtual IQueryable<MembershipEntity> GetQueryableMemberships(List<int> centerIds, bool? isArchive, bool includeAdditionalInfo)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            var centerService = _centerService;
            var relationTypeService = _relationTypeService;
            var relationRuleService = _relationRuleService;
            //centerService.MakeFriend(memberService);
            //relationTypeService.MakeFriend(memberService);
            //relationRuleService.MakeFriend(relationTypeService);

            //if (service != null)
            //    service.MakeFriend(memberService);

            var result = from m in memberService.GetDefaultQuery()
                         join c1 in centerService.GetDefaultQuery() on m.CenterId1 equals c1.Id
                         join c2 in centerService.GetDefaultQuery() on m.CenterId2 equals c2.Id
                         join rt in relationTypeService.GetDefaultQuery() on m.RelatedTypeId equals rt.Id
                         join rr in relationRuleService.GetDefaultQuery() on rt.Id equals rr.RelationTypeId
                         where ((centerIds.Contains(c1.Id) && c1.CenterTypeId == rr.CenterTypeId1) ||
                                (centerIds.Contains(c2.Id) && c2.CenterTypeId == rr.CenterTypeId2)) &&
                                ((isArchive.HasValue && m.IsArchive == isArchive.Value) || !isArchive.HasValue)
                         select new MembershipEntity
                         {
                             MemberId = m.Id,
                             SelfCenterId = centerIds.Contains(c1.Id) ? c1.Id : c2.Id,
                             SelfCenterTitle = centerIds.Contains(c1.Id) ? c1.Title : c2.Title,
                             SelfCenterIndex = centerIds.Contains(c1.Id) ? 1 : 2,
                             CenterId = centerIds.Contains(c1.Id) ? c2.Id : c1.Id,
                             CenterTitle = centerIds.Contains(c1.Id) ? c2.Title : c1.Title,
                             FromDate = m.FromDate,
                             ToDate = m.ToDate,
                             IsArchive = m.IsArchive,
                             RelationTypeId = m.RelatedTypeId,
                             RelationTypeTitle = rt.Title,
                             RelationTypeFarsiTitle = rt.FarsiTitle,
                             AdditionalInfo = includeAdditionalInfo ? m.AdditionalInfo : null,
                             OrderNo = m.OrderNo
                         };

            return result.AsQueryable();
        }

        public virtual IQueryable<MembershipTwoEntity> GetQueryableMemberships(RelationTypes relationType, bool? isArchive, bool includeAdditionalInfo)
        {
            //var  = new IField[0];
            var memberService = _memberService;
            var centerService = _centerService;
            var relationTypeService = _relationTypeService;
            var relationRuleService = _relationRuleService;
            //centerService.MakeFriend(memberService);
            //relationTypeService.MakeFriend(centerService);

            //if (service != null)
            //    service.MakeFriend(memberService);

            var result = from m in memberService.GetDefaultQuery()
                         join c1 in centerService.GetDefaultQuery() on m.CenterId1 equals c1.Id
                         join c2 in centerService.GetDefaultQuery() on m.CenterId2 equals c2.Id
                         join rt in relationTypeService.GetDefaultQuery() on m.RelatedTypeId equals rt.Id
                         where (m.RelatedTypeId == (int)relationType || (int)relationType == (int)RelationTypes.None) &&
                               ((isArchive.HasValue && m.IsArchive == isArchive.Value) || !isArchive.HasValue)
                         select new MembershipTwoEntity
                         {
                             MemberId = m.Id,
                             CenterId1 = c1.Id,
                             CenterTitle1 = c1.Title,
                             CenterId2 = c2.Id,
                             CenterTitle2 = c2.Title,
                             FromDate = m.FromDate,
                             ToDate = m.ToDate,
                             IsArchive = m.IsArchive,
                             RelationTypeId = rt.Id,
                             RelationTypeTitle = rt.Title,
                             RelationTypeFarsiTitle = rt.FarsiTitle,
                             AdditionalInfo = includeAdditionalInfo ? m.AdditionalInfo : null,
                             OrderNo = m.OrderNo
                         };

            return result.AsQueryable();
        }

        private RelationTypes GetServiceRelationType(RelationTypes relationType)
        {
            return relationType != RelationTypes.None ? relationType : RelationTypes.None;
        }
        #endregion
    }
}