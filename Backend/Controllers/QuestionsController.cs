using ElearningPlatform.Api.DTOs;
using ElearningPlatform.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuestionsController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var data = await _quizService.CreateQuestionAsync(dto);
            return Ok(data);
        }
    }
}