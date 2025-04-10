using System.ComponentModel.DataAnnotations;

namespace Taches.Management.Front.Models
{
    public class LoginModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string? PasswordHash { get; set; }
    }
}
