namespace MyApi.Models.DTOs.ProjectDtos;

public class CreateProjectDto
{
    public string Title { get; set; } = null!;
    public List<string> Descriptions { get; set; } = new();
}
