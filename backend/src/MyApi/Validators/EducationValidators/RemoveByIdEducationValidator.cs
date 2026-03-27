using FluentValidation;

namespace MyApi.Validators.EducationValidators;

public class RemoveByIdEducationValidator : AbstractValidator<string>
{
    public RemoveByIdEducationValidator()
    {
        RuleFor(id => id)
            .NotEmpty().WithMessage("ID alani bos olamaz.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Gecersiz ID formati.");
    }
}
