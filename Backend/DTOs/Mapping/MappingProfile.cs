using AutoMapper;
using ElearningPlatform.Api.DTOs;
using ElearningPlatform.Api.Models;

namespace ElearningPlatform.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Quiz, QuizDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Result, ResultDto>().ReverseMap();
        }
    }
}