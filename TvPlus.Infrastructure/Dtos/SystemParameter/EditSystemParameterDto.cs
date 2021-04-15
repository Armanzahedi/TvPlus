using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace TvPlus.Infrastructure.Dtos.SystemParameter
{
    public class EditSystemParameterDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public class EditSystemParameterValidator : AbstractValidator<EditSystemParameterDto>
    {

        public EditSystemParameterValidator()
        {
            RuleFor(sp => sp.Key).NotNull().NotEmpty();
            RuleFor(sp => sp.Value).NotNull().NotEmpty();
            RuleFor(sp => sp.Description).NotNull().NotEmpty();
        }
    }
}
