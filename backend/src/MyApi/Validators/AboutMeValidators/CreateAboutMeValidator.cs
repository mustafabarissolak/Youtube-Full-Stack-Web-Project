using FluentValidation;
using MyApi.Models.DTOs.AboutMeDtos;

namespace MyApi.Validators.AboutMeValidators;

public class CreateAboutMeValidator : AbstractValidator<CreateAboutMeDto>
{
    public CreateAboutMeValidator()
    {
        RuleFor(s => s.Title)
            .NotEmpty().WithMessage("Baslik boş geçilemez.")
            .MinimumLength(5).WithMessage("Baslik en az 5 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Baslik 50 karakteri geçemez.");

        RuleFor(s => s.Description)
            .NotEmpty().WithMessage("Aciklama boş geçilemez.")
            .MinimumLength(10).WithMessage("Aciklama en az 10 karakter olmalıdır.")
            .MaximumLength(500).WithMessage("Aciklama 500 karakteri geçemez.");
    }
}
