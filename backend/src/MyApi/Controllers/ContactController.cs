using Microsoft.AspNetCore.Mvc;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.ContactDtos;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactManager _manager;

    public ContactController(IContactManager manager)
    {
        _manager = manager;
    }

    [HttpGet("get-message-list")]
    public async Task<IActionResult> GetAll()
        => Ok(await _manager.GetAllAsync());

    [HttpGet("get-message-detail-by-id/{id}")]
    public async Task<IActionResult> GetAll(string id)
        => Ok(await _manager.GetByIdAsync(id));

    [HttpPost("send-message")]
    public async Task<IActionResult> Send(CreateContactDto dto)
    {
        await _manager.CreateAsync(dto);
        return Ok(new { Message = "Mesajiniz basariyla gonderildi. :) " });
    }

    [HttpPut("chage-read-satus-message/{id}")]
    public async Task<IActionResult> ChangeStatus(string id)
    {
        await _manager.ChangeStatus(id);
        return Ok(new { Message = "Mesajiniz basariyla guncellendi. :) " });
    }

    [HttpDelete("delete-message/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _manager.RemoveByIdAsync(id);
        return Ok(new { Message = "Mesajiniz basariyla silindi. :) " });
    }
}
