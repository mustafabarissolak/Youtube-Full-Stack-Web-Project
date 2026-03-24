using FluentValidation;
using MyApi.Models.DTOs.ProjectDtos;

namespace MyApi.Validators.ProjectValidators;

public class UpdateProjectValidator : AbstractValidator<UpdateProjectDto>
{
    public UpdateProjectValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id bilgisi boş olamaz.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Proje başlığı boş olamaz.")
            .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olmalıdır.");

        RuleFor(x => x.Descriptions)
            .NotNull().WithMessage("Açıklama listesi null olamaz.")
            .Must(d => d != null && d.Any()).WithMessage("En az bir açıklama eklemelisiniz."); // liste bos olamaz

        RuleForEach(x => x.Descriptions)
            .NotEmpty().WithMessage("Açıklama içeriği boş olamaz.")
            .MinimumLength(10).WithMessage("Her bir açıklama en az 10 karakter olmalıdır.");
    }
}