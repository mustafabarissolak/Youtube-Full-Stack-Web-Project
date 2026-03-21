namespace MyApi.Models.Entities;

public sealed class Education : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Department { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; } = null;
}
