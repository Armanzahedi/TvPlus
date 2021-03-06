using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvPlus.Infrastructure.Dtos.User
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "نام کاربری را وارد کنید.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "پسورد را وارد کنید.")]
        public string Password { get; set; }
    }
}
