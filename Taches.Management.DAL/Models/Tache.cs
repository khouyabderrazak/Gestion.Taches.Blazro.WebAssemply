using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Taches.Management.DAL.outher;

namespace Taches.Management.DAL.Models
{
    public class Tache : ModelBase
    {
        public string Nom { get; set; }
        public string? Description { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public TacheStatus? Statut { get; set; }
        public int? ProjetId { get; set; }
        [ForeignKey(nameof(ProjetId))]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public Projet? Projet { get; set; }

        public string UserId {get;set;}

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? applicationUser { get; set; }
    }

}
