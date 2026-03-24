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
        var projects = await _projectManager.GetAllForUiAsync();
        return Ok(projects);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectManager.GetAllAsync();
        return Ok(projects);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var project = await _projectManager.GetByIdAsync(id);
        return Ok(project);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProjectDto dto)
    {
        await _projectManager.CreateAsync(dto);
        return Ok(new { Message = "Proje basariyla eklendi." });
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateProjectDto dto)
    {
        await _projectManager.UpdateAsync(dto);
        return Ok(new { Message = "Proje basariyla guncellendi." });
    }

    [HttpDelete("delete-by-id/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _projectManager.RemoveByIdAsync(id);
        return Ok(new { Message = "Proje basariyla silindi." });
    }
}
