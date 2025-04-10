using Taches.Management.Services.Models.DTO;
namespace Taches.Management.Services.Interfaces
{
    public interface IUser
    {
        Task<User?>  authenticate(UserDto user);
        Task<User?> RegisterUser(User user);
        Task<bool> CheckUserName(string username);
        Task<bool> CheckUserEmail(string email);
        string CheckPasswordString(string password);
        Task<ICollection<User>> GetAllUsers();
        public Task<User> GetUserById(string id);
    }
}
