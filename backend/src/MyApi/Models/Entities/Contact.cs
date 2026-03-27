namespace MyApi.Models.Entities;

public sealed class Contact : BaseEntity
{
    public string SenderName { get; set; } = null!;
    public string SenderEmail { get; set; } = null!;
    public string SenderSubject { get; set; } = null!;
    public string SenderContent { get; set; } = null!;
    public bool IsRead { get; set; } = false;
}