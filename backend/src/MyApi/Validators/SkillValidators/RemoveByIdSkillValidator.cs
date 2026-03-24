using FluentValidation;

namespace MyApi.Validators.SkillValidators;

public class RemoveByIdSkillValidator : AbstractValidator<string>
{
    public RemoveByIdSkillValidator()
    {
        RuleFor(id => id)
             .NotEmpty().WithMessage("ID alanı boş olamaz.")
             .Must(id => Guid.TryParse(id, out _)).WithMessage("Geçersiz ID formatı.");
    }
}
