using ElearningPlatform.Api.DTOs;

namespace ElearningPlatform.Api.Services
{
    public interface ILessonService
    {
        Task<List<LessonDto>> GetByCourseIdAsync(int courseId);
        Task<LessonDto> CreateAsync(LessonDto dto);
        Task<LessonDto?> UpdateAsync(int id, LessonDto dto);
        Task<bool> DeleteAsync(int id);
    }
}