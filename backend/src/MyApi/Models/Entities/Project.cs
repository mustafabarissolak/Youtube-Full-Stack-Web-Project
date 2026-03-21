namespace MyApi.Models.Entities;

public sealed class Project : BaseEntity
{
    public string Title { get; set; } = null!;
    public ICollection<ProjectDescription> Descriptions { get; set; } = new List<ProjectDescription>();
}
