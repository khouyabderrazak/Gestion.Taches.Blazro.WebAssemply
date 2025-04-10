using BlazorWebAssembly.Services;
using Microsoft.AspNetCore.Components;
using Taches.Management.Front.Models;

namespace Taches.Management.Front.Pages
{
    public partial class AddUser
    {
        public User User { get; set; }

        [Inject]
        private IUserService _userService { get; set; }

        [Parameter]
        public EventCallback closeDialog { get; set; }


        protected override Task OnInitializedAsync()
        {
            User = new User();
            return base.OnInitializedAsync();
        }

        async Task Submit()
        {
            _userService.AddUser(User);
            await closeDialog.InvokeAsync();
        }
    }
}
