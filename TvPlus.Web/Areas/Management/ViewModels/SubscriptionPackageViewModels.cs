using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Core.Models;
using TvPlus.Utility.Enums;

namespace TvPlus.Web.Areas.Management.ViewModels
{
    public class SubscriptionPackageGrid
    {
        public SubscriptionPackageGrid(SubscriptionPackage model)
        {
            this.Id = model.Id;
            this.Price = model.Price;
            this.Discount = model.Discount;
            this.DiscountType = model.DiscountType;
            this.PriceAfterDiscount = model.PriceAfterDiscount();
            this.Duration = model.Duration;
        }
        public int Id { get; set; }
        public long Price { get; set; }
        public int Duration { get; set; }
        public long? Discount { get; set; }
        public DiscountType? DiscountType { get; set; }
        public long? PriceAfterDiscount { get; set; }
    }
}
