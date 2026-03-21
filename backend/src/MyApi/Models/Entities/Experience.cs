namespace MyApi.Models.Entities;

public sealed class Experience : BaseEntity
{
    public string Title { get; set; } = null!;
    public ICollection<ExperienceDescription> Descriptions { get; set; } = new List<ExperienceDescription>();
}
