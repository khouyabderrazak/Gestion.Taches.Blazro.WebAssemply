using System.ComponentModel.DataAnnotations;

namespace Taches.Management.DAL.Models
{
    public class ModelBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
