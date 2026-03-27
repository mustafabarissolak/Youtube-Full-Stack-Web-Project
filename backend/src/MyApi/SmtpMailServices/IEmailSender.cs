namespace MyApi.SmtpMailServices;

public interface IEmailSender
{
    Task SendEmailAsync(string to, string subject, string body);
}
