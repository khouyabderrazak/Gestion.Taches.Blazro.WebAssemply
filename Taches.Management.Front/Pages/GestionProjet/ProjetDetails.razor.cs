using BlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Taches.Management.Front.Services;
using Taches.Management.Front.Models;

namespace Taches.Management.Front.Pages.GestionProjet
{
    public partial class ProjetDetails
    {
        [Inject]
        private IProjetService _service { get; set; }

        [Parameter]
        public int id { get; set; }

        public ProjetModel projet { get; set; } = new ProjetModel();

        [Inject]
        public IUserService _userService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        ClaimsPrincipal user = null;

        protected override async Task OnInitializedAsync()
        {
            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                user = authState?.User;

            }

            await GetProjet();

            base.OnInitializedAsync();
        }

        async Task<bool> IsUserChefDeProjet()
        {

            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                user = authState?.User;
                return projet.ManagerID == user.FindFirst(ClaimTypes.NameIdentifier).Value;
            }

            return false;
        }

        private async Task GetProjet()
        {
            projet = await _service.GetOne(id);
        }

        async Task lancer()
        {
            await _service.OnLancer(id);
            await GetProjet();
        }

        async Task delancer()
        {
            await _service.OnDelancer(id);
            await GetProjet();


        }
        async Task valider()
        {
            await _service.OnValider(id);
            await GetProjet();

        }
        async Task invalider()
        {
            await _service.OnInvalider(id);
            await GetProjet();

        }
        async Task annuler()
        {
            await _service.OnAnnuler(id);
            await GetProjet();

        }

        async Task Repris()
        {
            await _service.OnReCree(id);
            await GetProjet();
        }
    }
}
