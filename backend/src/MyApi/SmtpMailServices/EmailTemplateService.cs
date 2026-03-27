using MyApi.Models.DTOs.ContactDtos;

namespace MyApi.SmtpMailServices;

public class EmailTemplateService : IEmailTemplateService
{
    readonly IEmailSender _emailSender;

    public EmailTemplateService(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task SendResetPasswordMailAsync(string resetLink, string email)
    {
        var subject = "Şifre Sıfırlama Talebi";
        var body = $@"<table width='100%' cellpadding='0' cellspacing='0' style='background:#f4f4f4; padding:40px 0; font-family:Arial, sans-serif;'>
                            <tr>
                                <td align='center'>
                                    <table width='600' cellpadding='0' cellspacing='0' style='background:white; border-radius:8px; overflow:hidden;'>
                                        <tr>
                                            <td style='background:#2D89EF; padding:20px; text-align:center; color:white; font-size:24px; font-weight:bold;'>
                                                Şifre Sıfırlama Talebi
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style='padding:30px; color:#444; font-size:16px; line-height:1.6;'>
                                                Merhaba,<br><br>
                                                Hesabınız için bir <strong>şifre sıfırlama</strong> talebi oluşturuldu.<br>
                                                Eğer bu isteği siz yapmadıysanız bu mesajı göz ardı edebilirsiniz.
                                                <br><br>
                                                Aşağıdaki butona tıklayarak şifrenizi sıfırlayabilirsiniz:
                                                <br><br>
                                                <a href='{resetLink}'
                                                   style='background:#2D89EF; color:white; padding:12px 25px; text-decoration:none;
                                                          font-size:16px; border-radius:6px; display:inline-block;'>
                                                    Şifreyi Sıfırla
                                                </a>
                                                <br><br>
                                                Güvenliğiniz bizim için önemlidir.
                                                <br><br>
                                                Saygılarımızla... <br>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style='background:#f0f0f0; padding:15px; text-align:center; font-size:12px; color:#888;'>
                                                Bu e-posta otomatik olarak oluşturulmuştur. Lütfen yanıtlamayınız.
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>";

        await _emailSender.SendEmailAsync(email!, subject, body);
    }

    public async Task SendContactMessageAsync(CreateContactDto message, string adminEmail)
    {
        if (string.IsNullOrEmpty(adminEmail))
            throw new Exception("Mail gonderilirken bir hata olustu. ");

        var subject = $"Yeni ziyaretçi mesajı: {message.SenderSubject}";
        var body = $@"
                        <table width='100%' cellpadding='0' cellspacing='0' style='background:#f4f4f4; padding:40px 0; font-family:Arial, sans-serif;'>
                            <tr>
                                <td align='center'>
                                    <table width='600' cellpadding='0' cellspacing='0' style='background:white; border-radius:8px; overflow:hidden;'>
                
                                        <tr>
                                            <td style='background:#28A745; padding:20px; text-align:center; color:white; font-size:22px; font-weight:bold;'>
                                                Yeni Ziyaretçi Mesajı
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style='padding:30px; color:#444; font-size:15px; line-height:1.6;'>

                                                <p>Bir ziyaretçi size mesaj gönderdi. Detaylar:</p>

                                                <table cellpadding='6' cellspacing='0' width='100%' style='border-collapse:collapse; margin-top:10px;'>
                            
                                                    <tr>
                                                        <td width='150' style='font-weight:bold; border-bottom:1px solid #eee;'>Ad</td>
                                                        <td style='border-bottom:1px solid #eee;'>{message.SenderName}</td>
                                                    </tr>

                                                    <tr>
                                                        <td style='font-weight:bold; border-bottom:1px solid #eee;'>Email</td>
                                                        <td style='border-bottom:1px solid #eee;'>{message.SenderEmail}</td>
                                                    </tr>

                                                    <tr>
                                                        <td style='font-weight:bold; border-bottom:1px solid #eee;'>Konu</td>
                                                        <td style='border-bottom:1px solid #eee;'>{message.SenderSubject}</td>
                                                    </tr>

                                                    <tr>
                                                        <td style='font-weight:bold;'>Tarih</td>
                                                        <td>{DateTime.Now}</td>
                                                    </tr>

                                                    <tr>
                                                        <td style='font-weight:bold; border-bottom:1px solid #eee; vertical-align:top;'>Mesaj</td>
                                                        <td style='border-bottom:1px solid #eee;'>{message.SenderContent}</td>
                                                    </tr>

                                                </table>

                                                <br>
                                                <p style='font-size:13px; color:#888;'>Bu mail Özgür Yaşar Mimarlık web sitesi tarafından otomatik olarak gönderilmiştir.</p>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td style='background:#f0f0f0; padding:15px; text-align:center; font-size:12px; color:#777;'>
                                                © 2025 Ozgur Yasar Mimarlik — Web Site Bildirimi
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>
                        ";

        await _emailSender.SendEmailAsync(adminEmail, subject, body);
    }

}