using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using TvPlus.Infrastructure.Dtos.ContactUs;

namespace TvPlus.Infrastructure.ViewModels
{
    public class PeopleGridViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EditPeopleViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
    public class EditPeopleValidator : AbstractValidator<EditPeopleViewModel>
    {

        public EditPeopleValidator()
        {
            RuleFor(sp => sp.FirstName).NotEmpty().WithName("نام");
            RuleFor(sp => sp.LastName).NotEmpty().WithName("نام خانوادگی");
        }
    }
}
