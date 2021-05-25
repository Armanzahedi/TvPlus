using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using TvPlus.Infrastructure.Dtos.ContactUs;

namespace TvPlus.Infrastructure.ViewModels
{
    public class CategoryGridViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "دسته بندی")]
        public int? ParentId { get; set; }
        [Display(Name = "نمایش در منو سایت")]
        public bool Show { get; set; }
    }

    public class EditCategoryValidator : AbstractValidator<EditCategoryViewModel>
    {

        public EditCategoryValidator()
        {
            RuleFor(sp => sp.Title).NotEmpty().WithName("عنوان");
        }
    }
}
