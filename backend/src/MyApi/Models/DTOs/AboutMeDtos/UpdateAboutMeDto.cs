namespace MyApi.Models.DTOs.AboutMeDtos;

public class UpdateAboutMeDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
