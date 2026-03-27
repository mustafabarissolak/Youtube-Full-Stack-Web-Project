using FluentValidation;

namespace MyApi.Validators.ContactValidators;

public class RemoveByIdContactValidator : AbstractValidator<string>
{
    public RemoveByIdContactValidator()
    {
        RuleFor(id => id)
            .NotEmpty().WithMessage("ID alani bos olamaz.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Gecersiz ID formati.");
    }
}
