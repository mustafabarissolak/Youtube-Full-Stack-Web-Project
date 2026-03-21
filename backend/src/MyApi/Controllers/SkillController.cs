using Microsoft.AspNetCore.Mvc;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.SkillDtos;
using MyApi.Repositories.Abstracts;

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


    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var skills = await _manager.GetAllAsync();
            return Ok(skills);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpGet("get-all-for-ui")]
    public async Task<IActionResult> GetAllForUi()
    {
        try
        {
            var skills = await _manager.GetAllForUiAsync();
            return Ok(skills);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var skill = await _manager.GetByIdAsync(id);
            return Ok(skill);
        }
        catch (Exception ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateSkillDto dto)
    {
        try
        {
            await _manager.CreateAsync(dto);
            return Ok(new { Message = "Yetenek başarıyla eklendi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateSkillDto dto)
    {
        try
        {
            await _manager.UpdateAsync(dto);
            return Ok(new { Message = "Yetenek başarıyla güncellendi." });
        }
        catch (Exception ex)
        {
            // Manager içinde fırlattığımız "bulunamadı" hatası buraya düşer
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _manager.RemoveAsync(id);
            return Ok(new { Message = "Yetenek başarıyla silindi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}