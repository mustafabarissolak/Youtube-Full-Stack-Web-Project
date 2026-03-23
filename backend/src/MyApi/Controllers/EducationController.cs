using Microsoft.AspNetCore.Mvc;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.EducationDtos;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationController : ControllerBase
{
    private readonly IEducationManager _manager;

    public EducationController(IEducationManager manager)
    {
        _manager = manager;
    }

    [HttpGet("get-all-for-ui")]
    public async Task<IActionResult> GetAllForUI()
    {
        try
        {
            return Ok(await _manager.GetAllForUiAsync());
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
            return Ok(await _manager.GetAllAsync());
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
            return Ok(await _manager.GetByIdAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateEducationDto dto)
    {
        try
        {
            await _manager.CreateAsync(dto);
            return Ok(new { Message = "Deneyim basariyla eklendi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateEducationDto dto)
    {
        try
        {
            await _manager.UpdateAsync(dto);
            return Ok(new { Message = "Deneyim basariyla guncellendi." });
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
            await _manager.RemoveAsync(id);
            return Ok(new { Message = "Deneyim basariyla silindi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
