namespace MyApi.Models.DTOs.SkillDtos;

public class UpdateSkillDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte Value { get; set; }
}
