using System.ComponentModel.DataAnnotations;

namespace ElearningPlatform.Api.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Content { get; set; } = string.Empty;

        public int OrderIndex { get; set; }

        public Course? Course { get; set; }
    }
}