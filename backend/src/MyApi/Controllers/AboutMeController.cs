using Microsoft.AspNetCore.Mvc;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.AboutMeDtos;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AboutMeController : ControllerBase
{
    private readonly IAboutMeManager _manager;

    public AboutMeController(IAboutMeManager manager)
    {
        _manager = manager;
    }

    [HttpGet("get-all-for-ui")]
    public async Task<IActionResult> GetAllForUi()
    {
        try
        {
            var result = await _manager.GetAllForUiAsync();
            return Ok(result);
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
            var result = await _manager.GetAllAsync();
            return Ok(result);
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
            var result = await _manager.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateAboutMeDto dto)
    {
        try
        {
            await _manager.CreateAsync(dto);
            return Ok(new { Message = "Hakkimda bilgisi basariyla eklendi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateAboutMeDto dto)
    {
        try
        {
            await _manager.UpdateAsync(dto);
            return Ok(new { Message = "Hakkimda bilgisi basariyla guncellendi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Remove(string id)
    {
        try
        {
            await _manager.RemoveByIdAsync(id);
            return Ok(new { Message = "Hakkimda bilgisi basariyla silindi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
