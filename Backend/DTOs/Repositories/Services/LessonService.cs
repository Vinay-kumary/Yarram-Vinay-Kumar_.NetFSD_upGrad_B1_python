using AutoMapper;
using ElearningPlatform.Api.Data;
using ElearningPlatform.Api.DTOs;
using ElearningPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ElearningPlatform.Api.Services
{
    public class LessonService : ILessonService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LessonService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LessonDto>> GetByCourseIdAsync(int courseId)
        {
            var data = await _context.Lessons
                .AsNoTracking()
                .Where(x => x.CourseId == courseId)
                .OrderBy(x => x.OrderIndex)
                .ToListAsync();

            return _mapper.Map<List<LessonDto>>(data);
        }

        public async Task<LessonDto> CreateAsync(LessonDto dto)
        {
            var lesson = _mapper.Map<Lesson>(dto);
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task<LessonDto?> UpdateAsync(int id, LessonDto dto)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == id);
            if (lesson == null) return null;

            lesson.CourseId = dto.CourseId;
            lesson.Title = dto.Title;
            lesson.Content = dto.Content;
            lesson.OrderIndex = dto.OrderIndex;

            await _context.SaveChangesAsync();

            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonId == id);
            if (lesson == null) return false;

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}