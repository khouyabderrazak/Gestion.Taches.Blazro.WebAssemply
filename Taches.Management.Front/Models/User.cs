using System.ComponentModel.DataAnnotations;

namespace Taches.Management.Front.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? Username { get; set; }

        [Required]
        public string Email { get; set; }

        public string? PasswordHash { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string? Tocken { get; set; }
    }
}
