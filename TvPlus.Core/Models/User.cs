using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlus.Core.Models
{
    public class User : IdentityUser
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public override string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "{0} وارد شده معتبر نیست")]
        public override string Email { get; set; }
        [Display(Name = "تلفن همراه")]
        public override string PhoneNumber { get; set; }
        public  string Avatar { get; set; }
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
        public ICollection<Comment> Comments { get; set; }
    }
}
