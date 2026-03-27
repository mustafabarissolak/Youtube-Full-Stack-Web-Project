using MyApi.Models.DTOs.ContactDtos;

namespace MyApi.SmtpMailServices;

public interface IEmailTemplateService
{
    Task SendResetPasswordMailAsync(string resetLink, string email);
    Task SendContactMessageAsync(CreateContactDto message, string adminEmail);
}
