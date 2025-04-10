using BlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using System.Security.Claims;
using Taches.Management.Front.Services;
using Taches.Management.Front.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Taches.Management.Front.Pages.GestionProjet
{
    public partial class ListProjet
    {
        [Inject]
        private NavigationManager? _navigationManager { get; set; }

        [Inject]
        private IProjetService _service { get; set; }

        List<ProjetModel> projets;

        public ProjetModel? projetChange { get; set; }

        public string? title { get; set; }

        bool dialogIsOpen = false;

        //public SearchProjetDto SearchProjetDto { get; set; }


        private RadzenDataGrid<ProjetModel> dataGrid;
        public int count { get; set; }

        [Inject]
        public IUserService _userService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        ClaimsPrincipal User = null;

        public List<string> Roles { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                // return claimsPrincipal that descripe the current User.
                User = authState?.User;
            }

            //SearchProjetDto = new SearchProjetDto();
            await base.OnInitializedAsync();

        }

        async Task<bool> IsUserChefDeProjet(ProjetModel projet)
        {

            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                User = authState?.User;
                return projet.ManagerID == User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }

            return false;
        }


        public async Task onItemChange()
        {
            await dataGrid.Reload();
            projetChange = null;
            dialogIsOpen = false;

        }

        public async Task onDelete(int id)
        {
            await _service.Delete(id);
            await dataGrid.Reload();

        }

        public async Task getAll(LoadDataArgs args)
        {
            projets = await _service.All();

            //if (!user.IsInRole("Admin"))
            //{
            //    var idUser = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //    projets = projets.Where(p =>
            //    p.ManagerID == idUser ||
            //    p.ProjetEquipes.Any(pe => pe.Equipe.ChefId == idUser) ||
            //    p.ProjetEquipes.Any(pe => pe.Equipe.EquipeCollaborateurs.Any(pec => pec.CollaborateurId == idUser))).ToList();
            //}

            count = projets.Count;
            projets = projets.Skip(args.Skip.Value).Take(args.Top.Value).ToList();
        }

        public async Task onUpdate(ProjetModel col)
        {
            title = "modifier Projet";
            projetChange = col;
            dialogIsOpen = true;
        }
        public void SelectionChangedEvent(object row)
        {
            //this.StateHasChanged();
        }

        void onAjouter()
        {
            projetChange = new ProjetModel();
            title = "Ajouter Projet";
            dialogIsOpen = true;
        }



        async Task onSearch()
        {
            await dataGrid.Reload();

        }

        async Task onClearSeatch()
        {
            await dataGrid.Reload();
        }

        async Task onVoirDetails(int id)
        {
            _navigationManager.NavigateTo("/projet/details/" + id);
        }

    }
}
