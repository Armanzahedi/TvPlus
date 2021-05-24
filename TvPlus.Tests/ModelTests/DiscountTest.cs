using System;
using System.Collections.Generic;
using System.Text;
using TvPlus.Core.Models;
using Xunit;

namespace TvPlus.Tests.ModelTests
{
    public class DiscountTest
    {
        [Fact]
        public void TestIsValidMethod()
        {
            var discount = new Discount{
                Id = 1,
                ValidFrom = DateTime.Now.AddDays(-10),
                ValidTo = DateTime.Now.AddDays(10),
            };
            Assert.True(discount.IsValid());
        }
    }
}
