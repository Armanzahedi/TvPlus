using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;

namespace TvPlus.Infrastructure.Dtos.User
{
    public class UserRegisterDto
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Information { get; set; }

    }
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {

        public UserRegisterValidator()
        {
            RuleFor(sp => sp.Email).NotEmpty().EmailAddress().WithName("ایمیل");
            RuleFor(sp => sp.UserName).NotEmpty().WithName("نام کاربری");
            RuleFor(sp => sp.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches(@"[A-Z]+").WithMessage("رمز عبور باید حداقل شامل یک حرف بزرگ باشد.")
                .Matches(@"[a-z]+").WithMessage("رمز عبور باید حداقل شامل یک حرف کوچک باشد.")
                .Matches(@"[0-9]+").WithMessage("رمز عبور باید حداقل شامل یک عدد باشد.")
                //.Matches(@"[\!\?\*\.]+").WithMessage("رمز عبور باید حداقل شامل یک کارکتر خاص عدد باشد.")
                .WithName("رمز عبور");
            RuleFor(sp => sp.FirstName).NotEmpty().MaximumLength(300).WithName("نام");
            RuleFor(sp => sp.LastName).NotEmpty().MaximumLength(300).WithName("نام خانوادگی");
        }
    }
}
