using ElearningPlatform.Api.DTOs;
using ElearningPlatform.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetByCourseId(int courseId)
        {
            var data = await _quizService.GetByCourseIdAsync(courseId);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] QuizDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var data = await _quizService.CreateQuizAsync(dto);
            return Ok(data);
        }

        [HttpGet("{quizId}/questions")]
        public async Task<IActionResult> GetQuestions(int quizId)
        {
            var data = await _quizService.GetQuestionsAsync(quizId);
            return Ok(data);
        }

        [HttpPost("{quizId}/submit")]
        public async Task<IActionResult> SubmitQuiz(int quizId, [FromBody] QuizSubmitDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var data = await _quizService.SubmitQuizAsync(quizId, dto);
                return Ok(data);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}