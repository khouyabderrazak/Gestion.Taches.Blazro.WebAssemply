using System.Net.Http.Json;
using Taches.Management.Front.Models;

namespace Taches.Management.Front.Services
{
    public class TacheService(HttpClient _httpClient) : ITacheService
    {
        public async Task<TacheModel> Add(TacheModel projet)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Taches", projet);

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<TacheModel>();
                return ResponseContent;
            }

            return null;
        }
        public async Task<List<TacheModel>> All(int projetId)
        {
            var response = await _httpClient.PostAsJsonAsync ("api/Taches/all", projetId);

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<List<TacheModel>>();
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
            var response = await _httpClient.GetAsync("api/Taches/delele");

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<bool>();
                return ResponseContent;
            }

            return false;
        }

        public async Task<TacheModel> GetOne(int id)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Taches/one", id);

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<TacheModel>();
                return ResponseContent;
            }

            return null;
        }
        public async Task<TacheModel> Update(TacheModel TacheModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Taches/update", TacheModel);

            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                var ResponseContent = await response.Content.ReadFromJsonAsync<TacheModel>();
                return ResponseContent;
            }

            return null;
        }
    }
}
