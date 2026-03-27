using FluentValidation;
using MyApi.Models.DTOs.EducationDtos;

namespace MyApi.Validators.EducationValidators;

public class UpdateEducationValidator : AbstractValidator<UpdateEducationDto>
{
    public UpdateEducationValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id bilgisi bos olamaz.");

        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Baslik bos gecilemez.")
            .MinimumLength(2).WithMessage("Baslik en az 2 karakter olmalidir.")
            .MaximumLength(50).WithMessage("Baslik 50 karakteri gecemez.");

        RuleFor(s => s.Department)
            .NotEmpty().WithMessage("Bolum bos gecilemez.")
            .MinimumLength(2).WithMessage("Bolum en az 2 karakter olmalidir.")
            .MaximumLength(100).WithMessage("Bolum 100 karakteri gecemez.");

        RuleFor(s => s.StartDate)
            .NotEmpty().WithMessage("Baslangic tarihi bos olamaz.");

        RuleFor(s => s.EndDate)
            .GreaterThanOrEqualTo(s => s.StartDate)
            .When(s => s.EndDate.HasValue)
            // Eger bitis tarihi varsa, baslangic tarihinden kucuk olamaz. Yoksa (null ise) sorun yok, aktif say.
            .WithMessage("Bitis tarihi baslangic tarihinden once olamaz.");
    }
}