namespace MyApi.Models.Entities;

public sealed class AboutMe : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}
