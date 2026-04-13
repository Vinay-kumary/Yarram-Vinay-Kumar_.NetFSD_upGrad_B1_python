using ElearningPlatform.Api.DTOs;

namespace ElearningPlatform.Api.Services
{
    public interface IResultService
    {
        Task<List<ResultDto>> GetByUserIdAsync(int userId);
    }
}