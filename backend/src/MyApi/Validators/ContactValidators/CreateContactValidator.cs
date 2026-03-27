using FluentValidation;
using MyApi.Models.DTOs.ContactDtos;

namespace MyApi.Validators.ContactValidators;

public class CreateContactValidator : AbstractValidator<CreateContactDto>
{
    public CreateContactValidator()
    {
        RuleFor(s => s.SenderName)
            .NotEmpty().WithMessage("Ad alani bos gecilemez.")
            .MinimumLength(2).WithMessage("Ad alani en az 2 karakter olmalidir.")
            .MaximumLength(30).WithMessage("Ad alani 30 karakteri gecemez.");

        RuleFor(s => s.SenderSubject)
            .NotEmpty().WithMessage("Konu bos gecilemez.")
            .MinimumLength(2).WithMessage("Konu en az 2 karakter olmalidir.")
            .MaximumLength(100).WithMessage("Konu 100 karakteri gecemez.");

        RuleFor(s => s.SenderContent)
            .NotEmpty().WithMessage("Mesaj bos gecilemez.")
            .MinimumLength(10).WithMessage("Mesaj en az 10 karakter olmalidir.")
            .MaximumLength(200).WithMessage("Mesaj 200 karakteri gecemez.");

        RuleFor(s => s.SenderEmail)
            .NotEmpty().WithMessage("E-posta boş geçilemez.")
            .EmailAddress().WithMessage("Lütfen geçerli bir E-posta formatı kullanın.") // Temel kontrol
            .Matches(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") // Regex ile kontrol
            .WithMessage("E-posta formatı hatalı. Lutfen gecerli bir E-posta girin. Örn: ad@ornek.com");
    }
}

