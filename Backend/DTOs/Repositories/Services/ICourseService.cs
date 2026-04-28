using ElearningPlatform.Api.DTOs;

namespace ElearningPlatform.Api.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllAsync();
        Task<CourseDto?> GetByIdAsync(int id);
        Task<CourseDto> CreateAsync(CourseDto dto);
        Task<CourseDto?> UpdateAsync(int id, CourseDto dto);
        Task<bool> DeleteAsync(int id);
    }
}