using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TvPlus.Core.Models;

namespace TvPlus.Infrastructure.ViewModels
{
    public class AddUserViewModel
    {
        public User User { get; set; }
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [StringLength(100, ErrorMessage = "{0} باید حداقل 6 کارکتر باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "عدم تطابق رمز عبور و تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }
    }
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "{0} وارد شده معتبر نیست")]
        public string Email { get; set; }
        [Display(Name = "تلفن همراه")]
        public  string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        [MaxLength(300)]
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FirstName { get; set; }
        [MaxLength(300)]
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string LastName { get; set; }
        [Display(Name = "اطلاعات")]
        [DataType(DataType.MultilineText)]
        public string Information { get; set; }
    }
}
