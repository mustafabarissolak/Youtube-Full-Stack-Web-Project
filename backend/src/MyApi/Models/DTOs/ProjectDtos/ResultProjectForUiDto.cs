namespace MyApi.Models.DTOs.ProjectDtos;

public class ResultProjectForUiDto
{
    public string Title { get; set; } = null!;
    public List<string> Descriptions { get; set; } = new List<string>();
}
