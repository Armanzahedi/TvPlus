using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Utility.Enums;

namespace TvPlus.Core.Models
{
    public class Discount : IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int UsageLimit { get; set; } = 1;
        public bool IsActive { get; set; } = true;
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int UsageCount { get; set; }
        public DiscountType DiscountType { get; set; }
        public long Amount { get; set; }
        public string Code { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsValid()
        {
            if (ValidTo < DateTime.Now || ValidFrom > DateTime.Now || UsageCount >= UsageLimit)
                return false;
            else
                return true;
        }
    }
}
