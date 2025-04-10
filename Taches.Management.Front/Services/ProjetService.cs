using System.Net.Http;
using System.Net.Http.Json;
using Taches.Management.Front.Models;

namespace Taches.Management.Front.Services
{
    public class ProjetService(HttpClient _httpClient) : IProjetService
    {
        public async Task<ProjetModel> Add(ProjetModel projet)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projets", projet);

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<ProjetModel>();
                return ResponseContent;
            }

            return null;
        }
        public async Task<List<ProjetModel>> All()
        {
            var response = await _httpClient.GetAsync("api/Projets");

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<List<ProjetModel>>();
                return ResponseContent;
            }

            return null;
        }

        public Task<bool> ChangeStatus(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.GetAsync("api/Projets/delele");

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<bool>();
                return ResponseContent;
            }

            return false; 
        }

        public async Task<ProjetModel> GetOne(int id)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projets/one", id);

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<ProjetModel>();
                return ResponseContent;
            }

            return null;
        }
        public async Task<ProjetModel> Update(ProjetModel ProjetModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projets/update", ProjetModel);

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<ProjetModel>();
                return ResponseContent;
            }

            return null;
        }


        public async Task OnAnnuler(int ProjetId)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projets/onAnnuler", ProjetId);
        }

        public async Task OnDelancer(int ProjetId)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projets/onDelancer", ProjetId);
        }

        public async Task OnInvalider(int ProjetId)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projets/onInvalider", ProjetId);

        }

        public async Task OnLancer(int ProjetId)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projets/onLancer", ProjetId);

        }

        public async Task OnReCree(int ProjetId)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projets/onReCree", ProjetId);

        }

        public async Task OnValider(int ProjetId)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projets/onValider", ProjetId);

        }
    }
}
