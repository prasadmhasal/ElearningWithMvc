using System.ComponentModel.DataAnnotations;

namespace ElearningWithMvc.Models
{
    public class CourseVideo
    {
        [Key]
        public int SubCourseId { get; set; }
        public int CourseId { get; set; }
        public string Subcourse { get; set; }
        public string Description { get; set; }
        public double price { get; set; }   

        public string Level { get; set; }   

        
    }
}
