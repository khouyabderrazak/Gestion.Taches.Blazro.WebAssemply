using System.ComponentModel.DataAnnotations;

namespace Taches.Management.Services.Models.DTO
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
