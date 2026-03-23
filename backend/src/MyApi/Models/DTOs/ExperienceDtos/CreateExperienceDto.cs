namespace MyApi.Models.DTOs.ExperienceDtos;

public class CreateExperienceDto
{
    public string Title { get; set; } = null!;
    public List<string> Descriptions { get; set; } = new();
}
