using ElearningPlatform.Api.DTOs;
using ElearningPlatform.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LessonDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var data = await _lessonService.CreateAsync(dto);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LessonDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var data = await _lessonService.UpdateAsync(id, dto);
            if (data == null) return NotFound(new { message = "Lesson not found." });
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _lessonService.DeleteAsync(id);
            if (!deleted) return NotFound(new { message = "Lesson not found." });
            return Ok(new { message = "Lesson deleted successfully." });
        }
    }
}