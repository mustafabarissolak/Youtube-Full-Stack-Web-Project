using FluentValidation;
using MyApi.Models.DTOs.LanguageDtos;

namespace MyApi.Validators.LanguageValidators;

public class CreateLanguageValidator : AbstractValidator<CreateLanguageDto>
{
    public CreateLanguageValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Dil adi bos gecilemez.")
            .MinimumLength(2).WithMessage("Dil adi en az 2 karakter olmalidir.")
            .MaximumLength(10).WithMessage("Dil adi 10 karakteri gecemez.");

        RuleFor(s => s.Description)
            .NotEmpty().WithMessage("Dil aciklamasi bos gecilemez.")
            .MinimumLength(2).WithMessage("Dil aciklamasi en az 2 karakter olmalidir.")
            .MaximumLength(20).WithMessage("Dil aciklamasi 20 karakteri gecemez.");
    }
}
