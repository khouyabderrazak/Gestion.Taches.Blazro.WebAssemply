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
    public class ProjetModel
    {
        public int? Id { get; set; }

        [Required]
        public string Nom { get; set; }
        public string? Description { get; set; }

        [Required]
        public DateTime? DateDebut { get; set; }

        [Required]
        public DateTime? DateFin { get; set; }
        public ProjetStatus? Statut { get; set; } = ProjetStatus.Creation;

        public string? ManagerID { get; set; }
        public ApplicationUser? Manager { get; set; }

    }
}
