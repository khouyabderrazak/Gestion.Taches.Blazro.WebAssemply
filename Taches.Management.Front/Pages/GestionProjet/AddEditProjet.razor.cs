using BlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Taches.Management.Front.Models;
using Taches.Management.Front.Services;
using Microsoft.AspNetCore.Components.Forms.Mapping;

namespace Taches.Management.Front.Pages.GestionProjet
{
    public partial class AddEditProjet
    {

        [Parameter]
        public ProjetModel? projetDto { get; set; }


        [Inject]
        private IProjetService _service { get; set; }


        [Parameter]
        public EventCallback onItemChange { get; set; }

        [Inject]
        public IUserService _userService { get; set; }

        [Inject]
        private IUserService userService { get; set; }

        public List<User> Users { get; set; }


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
          

            Users = await userService.GetAllUser();

            await base.OnInitializedAsync();
        }

        public async Task Submit()
        {
            await _service.Add(projetDto);
            await onItemChange.InvokeAsync();
        }
    }
}
