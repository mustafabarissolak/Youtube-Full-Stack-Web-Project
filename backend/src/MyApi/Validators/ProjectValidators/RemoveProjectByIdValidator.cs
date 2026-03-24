using FluentValidation;

namespace MyApi.Validators.ProjectValidators;

public class RemoveProjectByIdValidator : AbstractValidator<string>
{
    public RemoveProjectByIdValidator()
    {
        RuleFor(id => id)
            .NotEmpty().WithMessage("ID alanı boş olamaz.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Geçersiz ID formatı.");
    }
}