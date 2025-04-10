using BlazorWebAssembly.Utility;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Numerics;
using System.Security.Claims;
using Taches.Management.Front.Models;

namespace BlazorWebAssembly.Services
{
    public class UserService(HttpClient _httpClient, IMatToaster _toaster) : IUserService
    {
       
        public async Task<List<User>> GetAllUser()
        {
            var response =  await _httpClient.GetAsync("api/Users");

            if (response.IsSuccessStatusCode)
            {
                var listUser = await response.Content.ReadFromJsonAsync<List<User>>();

                return listUser;
            }

            return null;
        }

        public async Task<User> GetUserById(string Id)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users/OneUser", Id);

            if (response.IsSuccessStatusCode)
            {
                var User = await response.Content.ReadFromJsonAsync<User>();

                return User;
            }

            return null;
        }
        public async Task AddUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users/register", user);

            if (response.IsSuccessStatusCode)
            {
                _toaster.Add("User added successfully", MatToastType.Success, "Message de succès");

            }
            else
            {
                _toaster.Add("User added successfully", MatToastType.Danger, "Message de succès");
            }
        }


        public bool HasRole(string Role,ClaimsPrincipal User)
        {
            return User.Claims.Any(cl => cl.Type == "role" && cl.Value == Role);
        }


    }
}
