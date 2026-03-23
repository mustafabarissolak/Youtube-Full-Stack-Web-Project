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
        try
        {
            return Ok(await _experienceManager.GetAllForUiAsync());
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _experienceManager.GetAllAsync());
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
            return Ok(await _experienceManager.GetByIdAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateExperienceDto dto)
    {
        try
        {
            await _experienceManager.CreateAsync(dto);
            return Ok("Deneyim basarıyla eklendi.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateExperienceDto dto)
    {
        try
        {
            await _experienceManager.UpdateAsync(dto);
            return Ok("Deneyim basarıyla güncellendi.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
    [HttpDelete("delete-by-id/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _experienceManager.RemoveByIdAsync(id);
            return Ok("Deneyim basarıyla silindi.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
