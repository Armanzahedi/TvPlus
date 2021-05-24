using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;
using TvPlus.Utility.Enums;
using Xunit;

namespace TvPlus.Tests.ModelTests
{
    public class SubscriptionPackageTests
    {
        [Fact]
        public void TestPriceAfterDiscountAmount()
        {
            var subPack = new SubscriptionPackage
            {
                Id = 1,
                Duration = 1,
                Price = 10,
                DiscountType = DiscountType.Amount,
                Discount = 5
            };
            Assert.Equal(5,subPack.PriceAfterDiscount());
        }

        [Fact]
        public void TestPriceAfterDiscountPercentage()
        {
            var subPack = new SubscriptionPackage
            {
                Id = 1,
                Duration = 1,
                Price = 100,
                DiscountType = DiscountType.Percentage,
                Discount = 5
            };
            Assert.Equal(95, subPack.PriceAfterDiscount());
        }
    }
}
