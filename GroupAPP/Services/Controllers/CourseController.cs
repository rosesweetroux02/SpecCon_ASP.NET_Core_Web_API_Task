using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupAPP.Services.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet("approved")]
        public async Task<IActionResult> GetApprovedCourses()
        => Ok(await _service.GetApprovedNonAssessmentCoursesAsync());

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DTOs.UpdateCourseDto dto)
        {
            await _service.UpdateCourseAsync(id, dto);
            return NoContent();
        }
    }
}
