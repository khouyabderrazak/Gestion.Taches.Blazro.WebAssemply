using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace Taches.Management.Front.Pages
{
    public partial class Login
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationState { get; set; }

        [Inject]
        private NavigationManager _nav { get; set; }

        protected override async Task OnInitializedAsync()
        {

        }
    }
}
