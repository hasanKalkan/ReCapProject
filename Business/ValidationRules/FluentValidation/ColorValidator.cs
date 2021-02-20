using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
