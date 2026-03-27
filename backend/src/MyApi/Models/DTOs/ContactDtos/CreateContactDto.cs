namespace MyApi.Models.DTOs.ContactDtos;

public class CreateContactDto
{
    public string SenderName { get; set; } = null!;
    public string SenderEmail { get; set; } = null!;
    public string SenderSubject { get; set; } = null!;
    public string SenderContent { get; set; } = null!;
}
