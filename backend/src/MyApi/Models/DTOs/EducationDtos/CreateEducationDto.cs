namespace MyApi.Models.DTOs.EducationDtos;

public class CreateEducationDto
{
    public string Name { get; set; } = null!;
    public string Department { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
