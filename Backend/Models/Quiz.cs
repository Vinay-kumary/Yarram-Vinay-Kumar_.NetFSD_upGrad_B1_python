using System.ComponentModel.DataAnnotations;

namespace ElearningPlatform.Api.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public Course? Course { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}