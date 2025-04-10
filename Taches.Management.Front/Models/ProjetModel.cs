using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taches.Management.Front.outher;

namespace Taches.Management.Front.Models
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
        public ProjetStatus? Statut { get; set; }
        public string? ManagerID { get; set; }
        public User? Manager { get; set; }
    }
}
