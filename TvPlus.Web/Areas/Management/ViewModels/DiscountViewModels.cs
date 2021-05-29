using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TvPlus.Core.Models;
using TvPlus.Infrastructure.ViewModels;
using TvPlus.Utility.Enums;

namespace TvPlus.Web.Areas.Management.ViewModels
{
    public enum DiscountStatus
    {
        Valid = 1,
        InValid = 2,
        InActive = 3
    }
    public class DiscountGridViewModel
    {
        public DiscountGridViewModel(Discount model)
        {
            this.Id = model.Id;
            this.DiscountFor = string.IsNullOrEmpty(model.UserId)
                ? "برای همه"
                : $"برای {model.User.FirstName} {model.User.LastName}";
            this.DiscountType = model.DiscountType;
            this.Amount = model.Amount;
            this.ValidFrom = model.ValidFrom != null ? new PersianDateTime(model.ValidFrom.Value).ToString(PersianDateTimeFormat.Date) : "-";
            this.ValidTo = model.ValidTo != null ? new PersianDateTime(model.ValidTo.Value).ToString(PersianDateTimeFormat.Date) : "-";
            this.UsageStatus = $"{model.UsageLimit} / {model.UsageCount}";
            this.Code = model.Code;
            this.DiscountStatus = model.IsActive
                ? (model.IsValid() ? DiscountStatus.Valid : DiscountStatus.InValid)
                : DiscountStatus.InActive;
        }
        public int Id { get; set; }
        public string DiscountFor { get; set; }
        public DiscountType DiscountType { get; set; }
        public long Amount { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string UsageStatus { get; set; }
        public string Code { get; set; }
        public DiscountStatus DiscountStatus { get; set; }
    }

    public class EditDiscountViewModel
    {
        public EditDiscountViewModel()
        {
        }

        public EditDiscountViewModel(Discount model)
        {
            this.Discount = model;
            this.PersianValidFrom = model.ValidFrom != null
                ? new PersianDateTime(model.ValidFrom.Value).ToString(PersianDateTimeFormat.Date)
                : "";            
            this.PersianValidTo = model.ValidTo != null
                ? new PersianDateTime(model.ValidTo.Value).ToString(PersianDateTimeFormat.Date)
                : "";
        }
        public Discount Discount { get; set; }
        [Display(Name = "معتبر از تاریخ")]
        public string PersianValidFrom { get; set; }
        [Display(Name = "معتبر تا تاریخ")]
        public string PersianValidTo { get; set; }
    }
}
