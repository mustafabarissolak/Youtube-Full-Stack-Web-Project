namespace MyApi.Models.Entities;

public sealed class ExperienceDescription : BaseEntity
{
    public Guid ExperienceId { get; set; }
    public Experience Experience { get; set; } = null!;

    public string Value { get; set; } = null!;
}
