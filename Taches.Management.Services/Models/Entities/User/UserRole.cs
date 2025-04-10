namespace authentification_angular_aspNetCore_api.Models.Entities.User
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }

    }
}
