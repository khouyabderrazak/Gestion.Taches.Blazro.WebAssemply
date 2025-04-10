using System.Security.Claims;
using Taches.Management.Front.Models;
namespace BlazorWebAssembly.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUser();

        public Task<User> GetUserById(string Id);

        public Task AddUser(User user);


        public bool HasRole(string Role,ClaimsPrincipal User);
     

    }
}
