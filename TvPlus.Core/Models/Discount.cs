using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TvPlus.Utility.Enums;

namespace TvPlus.Core.Models
{
    public class Discount : IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        [Display(Name = "محدودیت استفاده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UsageLimit { get; set; } = 1;

        [Display(Name = "فعال")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "معتبر از تاریخ")]
        public DateTime? ValidFrom { get; set; }
        [Display(Name = "معتبر تا تاریخ")]
        public DateTime? ValidTo { get; set; }
        public int UsageCount { get; set; }
        [Display(Name = "نوع تخفیف")]
        public DiscountType DiscountType { get; set; }
        [Display(Name = "میزان")]
        public long Amount { get; set; }
        public string Code { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsValid()
        {
            if (ValidTo != null)
                if(ValidTo.Value.Date < DateTime.Now.Date)
                    return false;

            if (ValidFrom != null)
                if (ValidFrom.Value.Date > DateTime.Now.Date)
                    return false;

            if (UsageCount >= UsageLimit)
                return false;


            return true;
        }
    }
}
