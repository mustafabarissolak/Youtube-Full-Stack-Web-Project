namespace MyApi.Models.Entities;

public sealed class Language : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}