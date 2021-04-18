using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;

namespace TvPlus.Infrastructure.ViewModels
{
   public class SliderGridViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostTitle { get; set; }
    }
   public class EditSliderViewModel
   {
       public int Id { get; set; }
       [Display(Name = "عنوان")]
       public string Title { get; set; }
       [Display(Name = "پست")]
       public int PostId { get; set; }
       public string ImageName { get; set; }
   }
   public class EditSliderValidator : AbstractValidator<EditSliderViewModel>
   {

       public EditSliderValidator()
       {
           RuleFor(sp => sp.Title).NotEmpty().WithName("عنوان");
           RuleFor(sp => sp.PostId).NotEmpty().WithName("پست");
       }
   }
}
