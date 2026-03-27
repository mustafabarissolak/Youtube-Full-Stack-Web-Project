namespace MyApi.Models.DTOs.ContactDtos;

public class ListContactDto
{
    public string SenderName { get; set; } = null!;
    public string SenderEmail { get; set; } = null!;
    public string SenderSubject { get; set; } = null!;
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsRead { get; set; }
}
