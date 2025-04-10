
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Taches.Management.DAL.outher;

namespace Taches.Management.DAL.Models
{
    public class Projet : ModelBase
    {
        public string Nom { get; set; }
        public string? Description { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public ProjetStatus? Statut { get; set; } = ProjetStatus.Creation;

        // Relation : Un projet peut avoir plusieurs tâches
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public ICollection<Tache>? Taches { get; set; }


        public string? ManagerID { get; set; } 
        [ForeignKey(nameof(ManagerID))]
        public ApplicationUser? Manager { get; set; }
     
    }

}
