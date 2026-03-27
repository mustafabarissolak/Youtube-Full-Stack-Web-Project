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
        => Ok(await _manager.GetAllForUiAsync());

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
        => Ok(await _manager.GetAllAsync());

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(string id)
        => Ok(await _manager.GetByIdAsync(id));

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateAboutMeDto dto)
    {
        await _manager.CreateAsync(dto);
        return Ok(new { Message = "Hakkimda bilgisi basariyla eklendi." });
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateAboutMeDto dto)
    {
        await _manager.UpdateAsync(dto);
        return Ok(new { Message = "Hakkimda bilgisi basariyla guncellendi." });
    }

    [HttpDelete("delete-by-id/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _manager.RemoveByIdAsync(id);
        return Ok(new { Message = "Hakkimda bilgisi basariyla silindi." });
    }
}
