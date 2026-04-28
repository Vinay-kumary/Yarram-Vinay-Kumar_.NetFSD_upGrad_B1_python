using System.ComponentModel.DataAnnotations;

namespace ElearningPlatform.Api.DTOs
{
    public class QuizSubmitDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int QuizId { get; set; }

        [Required]
        public List<string> Answers { get; set; } = new();
    }
}