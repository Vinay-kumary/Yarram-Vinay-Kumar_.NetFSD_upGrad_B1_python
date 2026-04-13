using ElearningPlatform.Api.DTOs;

namespace ElearningPlatform.Api.Services
{
    public interface IQuizService
    {
        Task<List<QuizDto>> GetByCourseIdAsync(int courseId);
        Task<QuizDto> CreateQuizAsync(QuizDto dto);
        Task<List<QuestionDto>> GetQuestionsAsync(int quizId);
        Task<QuestionDto> CreateQuestionAsync(QuestionDto dto);
        Task<ResultDto> SubmitQuizAsync(int quizId, QuizSubmitDto dto);
    }
}