using System.ComponentModel.DataAnnotations;

namespace ElearningPlatform.Api.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public int QuizId { get; set; }

        [Required]
        [StringLength(300)]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string OptionA { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string OptionB { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string OptionC { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string OptionD { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string CorrectAnswer { get; set; } = "A";

        public Quiz? Quiz { get; set; }
    }
}