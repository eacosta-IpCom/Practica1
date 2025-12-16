using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Services;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/tasks")]

public class TasksController (TaskService _service): ControllerBase
{
    //get: api/task
    [HttpGet ("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    //post: api/task
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateTaskRequest request)
    {
        var task = _service.Create(request.Title);
        return Ok(task);
    }

    //put: api/tasks/{id}/complete

    [HttpPut("MarkComplete/{id}")]
    public IActionResult Complete(int id)
    {
        var result = _service.Complete(id);
        if (result.Status ==404)
            return NotFound(result);

        return Ok(result);
    }

}

public class CreateTaskRequest
{
    [Required]
    [MinLength(4)]
    public string Title {get; set;} = string.Empty;
}