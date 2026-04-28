using System.ComponentModel.DataAnnotations;

namespace ElearningPlatform.Api.DTOs
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public int QuizId { get; set; }

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        public string OptionA { get; set; } = string.Empty;

        [Required]
        public string OptionB { get; set; } = string.Empty;

        [Required]
        public string OptionC { get; set; } = string.Empty;

        [Required]
        public string OptionD { get; set; } = string.Empty;

        [Required]
        public string CorrectAnswer { get; set; } = "A";
    }
}