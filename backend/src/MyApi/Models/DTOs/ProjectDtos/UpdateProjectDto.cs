namespace MyApi.Models.DTOs.ProjectDtos;

public class UpdateProjectDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Descriptions { get; set; } = new();
}
