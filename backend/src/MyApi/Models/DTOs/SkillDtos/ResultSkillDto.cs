namespace MyApi.Models.DTOs.SkillDtos;

public class ResultSkillDto : ResultForUiSkillDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
