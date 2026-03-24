using Microsoft.AspNetCore.Mvc;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.SkillDtos;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{
    private readonly ISkillManager _manager;

    public SkillController(ISkillManager manager)
    {
        _manager = manager;
    }

    [HttpGet("get-all-for-ui")]
    public async Task<IActionResult> GetAllForUi()
        => Ok(await _manager.GetAllForUiAsync());

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
            => Ok(await _manager.GetAllAsync());

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(string id)
            => Ok(await _manager.GetByIdAsync(id));

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateSkillDto dto)
    {
        await _manager.CreateAsync(dto);
        return Ok(new { Message = "Beceri başarıyla eklendi." });
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateSkillDto dto)
    {
        await _manager.UpdateAsync(dto);
        return Ok(new { Message = "Beceri başarıyla güncellendi." });
    }

    [HttpDelete("delete-by-id/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _manager.RemoveAsync(id);
        return Ok(new { Message = "Beceri başarıyla silindi." });
    }
}