using AutoMapper;
using ElearningPlatform.Api.Data;
using ElearningPlatform.Api.DTOs;
using ElearningPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ElearningPlatform.Api.Services
{
    public class QuizService : IQuizService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QuizService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<QuizDto>> GetByCourseIdAsync(int courseId)
        {
            var data = await _context.Quizzes.AsNoTracking()
                .Where(x => x.CourseId == courseId)
                .ToListAsync();

            return _mapper.Map<List<QuizDto>>(data);
        }

        public async Task<QuizDto> CreateQuizAsync(QuizDto dto)
        {
            var quiz = _mapper.Map<Quiz>(dto);
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            return _mapper.Map<QuizDto>(quiz);
        }

        public async Task<List<QuestionDto>> GetQuestionsAsync(int quizId)
        {
            var data = await _context.Questions.AsNoTracking()
                .Where(x => x.QuizId == quizId)
                .ToListAsync();

            return _mapper.Map<List<QuestionDto>>(data);
        }

        public async Task<QuestionDto> CreateQuestionAsync(QuestionDto dto)
        {
            var question = _mapper.Map<Question>(dto);
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return _mapper.Map<QuestionDto>(question);
        }

        public async Task<ResultDto> SubmitQuizAsync(int quizId, QuizSubmitDto dto)
        {
            var quiz = await _context.Quizzes.Include(x => x.Questions)
                .FirstOrDefaultAsync(x => x.QuizId == quizId);

            if (quiz == null)
            {
                throw new InvalidOperationException("Quiz not found.");
            }

            int score = 0;

            for (int i = 0; i < quiz.Questions.Count && i < dto.Answers.Count; i++)
            {
                var correct = quiz.Questions.OrderBy(q => q.QuestionId).ToList()[i].CorrectAnswer;
                if (string.Equals(correct, dto.Answers[i], StringComparison.OrdinalIgnoreCase))
                {
                    score++;
                }
            }

            var result = new Result
            {
                UserId = dto.UserId,
                QuizId = dto.QuizId,
                Score = score,
                AttemptDate = DateTime.UtcNow
            };

            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResultDto>(result);
        }
    }
}