using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taches.Management.DAL.Models;
using Taches.Management.DAL.outher;

namespace Taches.Management.Services.Models
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
        public Projet? Projet { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? applicationUser { get; set; }
    }
}
