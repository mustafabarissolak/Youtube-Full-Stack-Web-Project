using FluentValidation;

namespace MyApi.Validators.ExperienceValidators;

public class RemoveExperienceByIdValidator : AbstractValidator<string>
{
    public RemoveExperienceByIdValidator()
    {
        RuleFor(id => id)
            .NotEmpty().WithMessage("ID alanı boş olamaz.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Geçersiz ID formatı.");
    }
}
