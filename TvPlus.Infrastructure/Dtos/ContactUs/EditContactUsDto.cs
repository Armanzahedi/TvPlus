using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace TvPlus.Infrastructure.Dtos.ContactUs
{
    public class EditContactUsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SectionOneTitle { get; set; }
        public string SectionOneDescription { get; set; }
        public string SectionTwoTitle { get; set; }
        public string SectionTwoDescription { get; set; }
        public string SectionThreeTitle { get; set; }
        public string SectionThreeDescription { get; set; }
        public string SectionFourTitle { get; set; }
        public string SectionFourDescription { get; set; }
        public string SectionFiveTitle { get; set; }
        public string SectionFiveDescription { get; set; }
        public string SectionSixTitle { get; set; }
        public string SectionSixDescription { get; set; }
    }
    public class EditContactUsValidator : AbstractValidator<EditContactUsDto>
    {

        public EditContactUsValidator()
        {
            RuleFor(sp => sp.Title).NotEmpty();
            RuleFor(sp => sp.SectionOneTitle).NotEmpty();
            RuleFor(sp => sp.SectionOneDescription).NotEmpty();
            RuleFor(sp => sp.SectionTwoTitle).NotEmpty();
            RuleFor(sp => sp.SectionTwoDescription).NotEmpty();
            RuleFor(sp => sp.SectionThreeTitle).NotEmpty();
            RuleFor(sp => sp.SectionThreeDescription).NotEmpty();
            RuleFor(sp => sp.SectionFourTitle).NotEmpty();
            RuleFor(sp => sp.SectionFourDescription).NotEmpty();
            RuleFor(sp => sp.SectionFiveTitle).NotEmpty();
            RuleFor(sp => sp.SectionFiveDescription).NotEmpty();
            RuleFor(sp => sp.SectionSixTitle).NotEmpty();
            RuleFor(sp => sp.SectionSixDescription).NotEmpty();
        }
    }
}
