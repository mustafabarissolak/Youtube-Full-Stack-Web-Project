using FluentValidation;
using MyApi.Models.DTOs.SkillDtos;

namespace MyApi.Validators.SkillValidators;

public class UpdateSkillValidator : AbstractValidator<UpdateSkillDto>
{
    public UpdateSkillValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id bilgisi boş olamaz.");

        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("Yetenek adı boş geçilemez.")
            .MinimumLength(2).WithMessage("Yetenek adı en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Yetenek adı 50 karakteri geçemez.");

        RuleFor(s => s.Value)
            .InclusiveBetween((byte)0, (byte)100)
            .WithMessage("Yetenek değeri 0 ile 100 arasında olmalıdır.");
    }
}
