using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupAPP.Services.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _service;

        public SkillController(ISkillService service)
        {
            _service = service;
        }

        [HttpGet("last-year")]
        public async Task<IActionResult> GetLastYearSkills()
        => Ok(await _service.GetSkillsCreatedLastYearAsync());

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }


}
