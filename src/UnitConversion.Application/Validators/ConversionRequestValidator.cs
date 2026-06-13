using FluentValidation;
using UnitConversion.Application.DTOs;

namespace UnitConversion.Application.Validators;

public sealed class ConversionRequestValidator
    : AbstractValidator<ConversionRequest>
{
    public ConversionRequestValidator()
    {
        RuleFor(x => x.Value)
            .NotNull()
            .WithMessage("Value is required.");

        RuleFor(x => x.FromUnit)
            .NotEmpty()
            .WithMessage("FromUnit is required.")
            .MaximumLength(50);

        RuleFor(x => x.ToUnit)
            .NotEmpty()
            .WithMessage("ToUnit is required.")
            .MaximumLength(50);
    }
}