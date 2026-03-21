namespace MyApi.Models.DTOs.EducationDtos;

public class ResultEducationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Department { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public class ResultForUiEducationDto
{
    public string Name { get; set; } = null!;
    public string Department { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}

public class CreateEducationDto
{
    public string Name { get; set; } = null!;
    public string Department { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}

public class UpdateEducationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Department { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}