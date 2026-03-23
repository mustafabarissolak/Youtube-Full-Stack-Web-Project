using Microsoft.AspNetCore.Mvc;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.ProjectDtos;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectManager _projectManager;

    public ProjectController(IProjectManager projectManager)
    {
        _projectManager = projectManager;
    }

    [HttpGet("get-all-for-ui")]
    public async Task<IActionResult> GetAllForUi()
    {
        try
        {
            var projects = await _projectManager.GetAllForUiAsync();
            return Ok(projects);
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
            var projects = await _projectManager.GetAllAsync();
            return Ok(projects);
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
            var project = await _projectManager.GetByIdAsync(id);
            return Ok(project);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProjectDto dto)
    {
        try
        {
            await _projectManager.CreateAsync(dto);
            return Ok(new { Message = "Proje basariyla eklendi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateProjectDto dto)
    {
        try
        {
            await _projectManager.UpdateAsync(dto);
            return Ok(new { Message = "Proje basariyla guncellendi." });
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
            await _projectManager.RemoveByIdAsync(id);
            return Ok(new { Message = "Proje basariyla silindi." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
