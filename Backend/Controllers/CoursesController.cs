using ElearningPlatform.Api.DTOs;
using ElearningPlatform.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILessonService _lessonService;

        public CoursesController(ICourseService courseService, ILessonService lessonService)
        {
            _courseService = courseService;
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _courseService.GetAllAsync();

                if (data == null)
                {
                    return Ok(new List<CourseDto>());
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _courseService.GetByIdAsync(id);

                if (data == null)
                {
                    return NotFound(new { message = "Course not found." });
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var data = await _courseService.CreateAsync(dto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var data = await _courseService.UpdateAsync(id, dto);

                if (data == null)
                {
                    return NotFound(new { message = "Course not found." });
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _courseService.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound(new { message = "Course not found." });
                }

                return Ok(new { message = "Course deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{courseId}/lessons")]
        public async Task<IActionResult> GetLessons(int courseId)
        {
            try
            {
                var data = await _lessonService.GetByCourseIdAsync(courseId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}