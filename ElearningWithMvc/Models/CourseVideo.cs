using System.ComponentModel.DataAnnotations;

namespace ElearningWithMvc.Models
{
    public class CourseVideo
    {
        [Key]
        public int CourseVideoId { get; set; }

        public string Coursename { get; set; }

        public string Subcourse { get; set; }

        public string VideoTitle { get; set; }

        public string VideoUrl { get; set; }

        public int CourseId { get; set; }
    }
}
