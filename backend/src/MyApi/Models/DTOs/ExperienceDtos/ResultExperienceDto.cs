namespace MyApi.Models.DTOs.ExperienceDtos;

public class ResultExperienceDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Descriptions { get; set; } = new();
}
