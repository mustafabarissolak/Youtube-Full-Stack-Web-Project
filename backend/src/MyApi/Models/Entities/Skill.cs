namespace MyApi.Models.Entities;

public sealed class Skill : BaseEntity
{
    public string Name { get; set; } = null!;
    public byte Value { get; set; }
}
