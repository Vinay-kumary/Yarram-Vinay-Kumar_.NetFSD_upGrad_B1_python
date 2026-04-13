using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using ElearningPlatform.Api.Data;
using ElearningPlatform.Api.DTOs;
using ElearningPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ElearningPlatform.Api.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> RegisterAsync(UserRegisterDto dto)
        {
            var exists = await _context.Users.AnyAsync(x => x.Email == dto.Email);
            if (exists)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> UpdateAsync(int id, UserRegisterDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null) return null;

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.PasswordHash = HashPassword(dto.Password);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }
    }
}