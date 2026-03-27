using FluentValidation;

namespace MyApi.Validators.LanguageValidators;

public class RemoveByIdLanguageValidator : AbstractValidator<string>
{
    public RemoveByIdLanguageValidator()
    {
        RuleFor(id => id)
            .NotEmpty().WithMessage("ID alani bos olamaz.")
            .Must(id => Guid.TryParse(id, out _))
            .WithMessage("Gecersiz ID formati.");
    }
}