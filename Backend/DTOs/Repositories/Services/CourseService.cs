using AutoMapper;
using ElearningPlatform.Api.Data;
using ElearningPlatform.Api.DTOs;
using ElearningPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ElearningPlatform.Api.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CourseService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var courses = await _context.Courses
                .AsNoTracking()
                .ToListAsync();

            if (courses == null || courses.Count == 0)
            {
                return new List<CourseDto>();
            }

            return _mapper.Map<List<CourseDto>>(courses);
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
            {
                return null;
            }

            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> CreateAsync(CourseDto dto)
        {
            var course = _mapper.Map<Course>(dto);
            course.CreatedAt = DateTime.UtcNow;

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto?> UpdateAsync(int id, CourseDto dto)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
            {
                return null;
            }

            course.Title = dto.Title;
            course.Description = dto.Description;
            course.CreatedBy = dto.CreatedBy;

            await _context.SaveChangesAsync();

            return _mapper.Map<CourseDto>(course);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
            {
                return false;
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}