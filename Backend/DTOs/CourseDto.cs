using System.ComponentModel.DataAnnotations;

namespace ElearningPlatform.Api.DTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int CreatedBy { get; set; }
    }
}