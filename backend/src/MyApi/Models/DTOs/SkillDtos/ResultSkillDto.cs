namespace MyApi.Models.DTOs.SkillDtos;

public class ResultSkillDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte Value { get; set; }
}
