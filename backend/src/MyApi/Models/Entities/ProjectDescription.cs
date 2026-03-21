namespace MyApi.Models.Entities;

public sealed class ProjectDescription : BaseEntity
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    public string Value { get; set; } = null!;
}
