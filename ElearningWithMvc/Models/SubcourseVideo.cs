using System.ComponentModel.DataAnnotations;

namespace ElearningWithMvc.Models
{
    public class SubcourseVideo
    {
        [Key]
        public int SubVideoId { get; set; }

        public int SubCourseId { get; set; }
        public string Title { get; set; }

        public string Url { get; set; }


    }
}
