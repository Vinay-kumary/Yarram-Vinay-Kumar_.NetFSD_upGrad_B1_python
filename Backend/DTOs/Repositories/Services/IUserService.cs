using ElearningPlatform.Api.DTOs;

namespace ElearningPlatform.Api.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(UserRegisterDto dto);
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> UpdateAsync(int id, UserRegisterDto dto);
    }
}