namespace MyApi.Models.DTOs.ExperienceDtos;

public class ResultExperienceForUiDto
{
    public string Title { get; set; } = null!;
    public List<string> Descriptions { get; set; } = new List<string>();
}
