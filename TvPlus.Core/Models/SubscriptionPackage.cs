using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text;
using TvPlus.Utility.Enums;

namespace TvPlus.Core.Models
{
    public class SubscriptionPackage : IBaseEntity
    {
        public int Id { get; set; }
        [Display(Name = "مدت زمان (ماه)")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Duration { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long Price { get; set; }
        [Display(Name = "نوع تخفیف")]
        public DiscountType? DiscountType { get; set; }
        [Display(Name = "میزان تخفیف")]
        public long? Discount { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertUser { get; set; }
        public string UpdateUser { get; set; }
        public bool IsDeleted { get; set; }

        public long? PriceAfterDiscount()
        {
            long? price = this.Price;
            if (this.DiscountType != null && this.Discount != null && this.Discount > 0)
            {
                if (this.DiscountType == Utility.Enums.DiscountType.Percentage)
                {
                    price = this.Price - (this.Price * this.Discount / 100);
                } 
                else if (this.DiscountType == Utility.Enums.DiscountType.Amount)
                {
                    price = this.Price - this.Discount;
                }

            }
            return price;
        }
    }
}
