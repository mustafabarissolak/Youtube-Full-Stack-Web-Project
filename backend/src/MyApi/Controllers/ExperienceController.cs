using Microsoft.AspNetCore.Mvc;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.ExperienceDtos;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExperienceController : ControllerBase
{
    private readonly IExperienceManager _experienceManager;

    public ExperienceController(IExperienceManager experienceManager)
    {
        _experienceManager = experienceManager;
    }

    [HttpGet("get-all-for-ui")]
    public async Task<IActionResult> GetAllForUi()
    {
        var Experiences = await _experienceManager.GetAllForUiAsync();
        return Ok(Experiences);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var Experiences = await _experienceManager.GetAllAsync();
        return Ok(Experiences);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var Experience = await _experienceManager.GetByIdAsync(id);
        return Ok(Experience);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateExperienceDto dto)
    {
        await _experienceManager.CreateAsync(dto);
        return Ok(new { Message = "Deneyim basariyla eklendi." });
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateExperienceDto dto)
    {
        await _experienceManager.UpdateAsync(dto);
        return Ok(new { Message = "Deneyim basariyla guncellendi." });
    }

    [HttpDelete("delete-by-id/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _experienceManager.RemoveByIdAsync(id);
        return Ok(new { Message = "Deneyim basariyla silindi." });
    }
}
