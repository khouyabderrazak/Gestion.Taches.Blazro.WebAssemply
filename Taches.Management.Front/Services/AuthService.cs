using Blazored.LocalStorage;
using BlazorWebAssembly.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Taches.Management.Front.Models;
using static System.Net.WebRequestMethods;


namespace Taches.Management.Front.Services
{
    public class AuthService : IAuthService {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }
        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users/authenticate", loginModel);

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<LoginResult>();

                if (ResponseContent!.Token is not null)
                {
                    await _localStorage.SetItemAsync("authToken", ResponseContent.Token);

                    Console.WriteLine("access token :" + ResponseContent.Token);

                    ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(ResponseContent.Token!);

                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", ResponseContent.Token);

                    return ResponseContent;
                }
                else
                {
                    return null;
                }
            }
            else
            {

            return null;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;

            _navigationManager.NavigateTo("login");
        }
    }
}
