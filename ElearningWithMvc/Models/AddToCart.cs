using System.ComponentModel.DataAnnotations;

namespace ElearningWithMvc.Models
{
    public class AddToCart
    {
        [Key]
        public int CartId { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public string CourseImage { get; set; }
        public double Price { get; set; }

        
        public string? SubCourse { get; set; }
        public string? VideoTitle { get; set; }
        public string? VideoUrl { get; set; }

        public string Suser { get; set; }
        
        public int? Quantity { get; set; } = 1; 
    }
}
