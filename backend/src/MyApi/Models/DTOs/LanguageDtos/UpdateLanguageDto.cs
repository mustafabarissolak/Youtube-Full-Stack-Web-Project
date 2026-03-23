namespace MyApi.Models.DTOs.LanguageDtos;

public class UpdateLanguageDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}