namespace MyApi.SmtpMailServices;

public class SmtpSettings
{
    public string Server { get; set; } = null!;
    public int Port { get; set; }
    public bool EnableSsl { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string SenderName { get; set; } = null!;
    public string SenderEmail { get; set; } = null!;

    public string AdminEmail { get; set; } = null!;
}
