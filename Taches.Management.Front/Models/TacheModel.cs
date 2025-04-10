using System.ComponentModel.DataAnnotations;
using Taches.Management.Front.outher;
namespace Taches.Management.Front.Models
{
    public class TacheModel
    {
        public int? Id { get; set; }

        [Required]
        public string Nom { get; set; }
        public string? Description { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public TacheStatus? Statut { get; set; }
        [Required]
        public int? ProjetId { get; set; }
        public ProjetModel ? Projet { get; set; }

        public string? UserId { get; set; }
        public User? applicationUser { get; set; }
    }
}
