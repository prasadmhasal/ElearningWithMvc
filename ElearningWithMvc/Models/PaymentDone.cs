using System.ComponentModel.DataAnnotations;

namespace ElearningWithMvc.Models
{
    public class PaymentDone
    {
        [Key]
        public int PaymentId { get; set; }

        public int SubCourseId { get; set; }

        public string UserEmail {  get; set; }
    }
}
