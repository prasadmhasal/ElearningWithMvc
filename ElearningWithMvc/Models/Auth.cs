using System.ComponentModel.DataAnnotations;

namespace ElearningWithMvc.Models
{
    public class Auth
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Urole { get; set; }

        public string Status { get; set; }
    }
}
