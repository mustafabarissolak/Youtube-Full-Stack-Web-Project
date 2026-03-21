namespace MyApi.Models.DTOs.LanguageDtos;

public class ResultLanguageDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public class ResultForUiLanguageDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class CreateLanguageDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class UpdateLanguageDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}