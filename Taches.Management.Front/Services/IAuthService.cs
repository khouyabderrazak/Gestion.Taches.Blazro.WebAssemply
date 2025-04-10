using Taches.Management.Front.Models;

namespace Taches.Management.Front.Services
{
    public interface IAuthService {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
