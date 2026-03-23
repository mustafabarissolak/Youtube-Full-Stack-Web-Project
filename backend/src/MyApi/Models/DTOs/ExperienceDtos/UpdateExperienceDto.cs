namespace MyApi.Models.DTOs.ExperienceDtos;

public class UpdateExperienceDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Descriptions { get; set; } = new();
}