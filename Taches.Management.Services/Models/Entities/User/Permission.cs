using System.ComponentModel.DataAnnotations;

namespace authentification_angular_aspNetCore_api.Models.Entities.User
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RolePermission>? RolePermissions { get; set; }
    }
}
