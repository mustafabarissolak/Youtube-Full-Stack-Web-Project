namespace MyApi.Models.DTOs.ProjectDtos;

public class ResultProjectDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Title { get; set; } = null!;
    public List<string> Descriptions { get; set; } = new();
}
