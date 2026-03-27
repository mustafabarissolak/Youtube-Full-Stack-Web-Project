using FluentValidation;

namespace MyApi.Validators.AboutMeValidators;

public class RemoveByIdAboutMeValidator : AbstractValidator<string>
{
    public RemoveByIdAboutMeValidator()
    {
        RuleFor(id => id)
             .NotEmpty().WithMessage("ID alanı boş olamaz.")
             .Must(id => Guid.TryParse(id, out _)).WithMessage("Geçersiz ID formatı.");
    }
}
