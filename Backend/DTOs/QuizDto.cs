using System.ComponentModel.DataAnnotations;

namespace ElearningPlatform.Api.DTOs
{
    public class QuizDto
    {
        public int QuizId { get; set; }
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
    }
}