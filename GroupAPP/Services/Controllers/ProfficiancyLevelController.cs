using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/profficiancy-levels")]
public class ProfficiancyLevelController : ControllerBase
{
    private readonly IProfficiancyLevelService _service;

    public ProfficiancyLevelController(IProfficiancyLevelService service)
    {
        _service = service;
    }

    [HttpGet("active")]
    public IActionResult GetActive()
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}

