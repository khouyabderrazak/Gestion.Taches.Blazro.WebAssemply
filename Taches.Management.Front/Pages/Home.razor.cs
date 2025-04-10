using BlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Taches.Management.Front.Models;

namespace Taches.Management.Front.Pages
{
    public partial class Home
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationState { get; set; }

        public IEnumerable<Claim> permissions { get; set; }

        [Inject]
        private IUserService _userService { get; set; }

        public List<User> users { get; set; }
        public ClaimsPrincipal User { get; set; }

        public bool dialogIsOpen { get; set; } = false;

        public List<Claim> claims { get; set; }
        public string Role { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (authenticationState is not null)
            {
                var authState = await authenticationState;

                // return claimsPrincipal that descripe the current User.
                User = authState?.User;
                Role = User?.Claims?.FirstOrDefault(cl => cl.Type == "role").Value.ToString();

                //User.IsInRole("Admin");
                if (Role == "Admin")
                {
                    users = await _userService?.GetAllUser();

                }
                else if (Role == "User")
                {

                    var idUser = User.Claims.FirstOrDefault(cl => cl.Type == "nameid").Value.ToString();

                    var authenticatedUser = await _userService.GetUserById(idUser);

                    users = new List<User>()
                    {
                        authenticatedUser
                    };
                }

            }
        }

        async Task OnCloseDialog()
        {
            dialogIsOpen = !dialogIsOpen;
            users = await _userService?.GetAllUser();
        }
    }
}
