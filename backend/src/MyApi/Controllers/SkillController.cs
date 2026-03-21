using Microsoft.AspNetCore.Mvc;
using MyApi.Models.DTOs.SkillDtos;
using MyApi.Repositories.Abstracts;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{
    private readonly ISkillRepository _skillRepository;

    public SkillController(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    [HttpGet("get-skills")]
    public async Task<IActionResult> GetAll() => Ok(await _skillRepository.GetAllAsync());

    [HttpGet("get-skills-for-ui")]
    public async Task<IActionResult> GetAllForUi() => Ok(await _skillRepository.GetAllForUiAsync());

    [HttpGet("get-skill/{id}")]
    public async Task<IActionResult> GetSinge(string id) => Ok(await _skillRepository.GetByIdAsync(Guid.Parse(id)));

    [HttpPost("create-skill")]
    public async Task<IActionResult> Create(CreateSkillDto dto)
    {
        await _skillRepository.CreateAsync(new()
        {
            Name = dto.Name,
            Value = dto.Value
        });
        await _skillRepository.SaveAsync();
        return Ok(new { Message = "Skill created successfully." });
    }

    [HttpPut("update-skill")]
    public async Task<IActionResult> Update(UpdateSkillDto dto)
    {
        var skill = await _skillRepository.GetByIdAsync(dto.Id);
        if (skill is null)
            return NotFound(new { Message = "Skill not found." });

        skill.Name = dto.Name;
        skill.Value = dto.Value;

        _skillRepository.Update(new Models.Entities.Skill
        {
            Id = dto.Id,
            Name = dto.Name,
            Value = dto.Value,
        });
        await _skillRepository.SaveAsync();
        return Ok(new { Message = "Skill updated successfully." });
    }

    [HttpDelete("delete-skill/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var skill = await _skillRepository.GetByIdAsync(Guid.Parse(id));
        if (skill is null)
            return NotFound(new { Message = "Skill not found." });
        _skillRepository.RemoveById(Guid.Parse(id));
        await _skillRepository.SaveAsync();
        return Ok(new { Message = "Skill deleted successfully." });
    }
}
