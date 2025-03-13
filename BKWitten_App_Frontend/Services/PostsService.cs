using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
namespace BKWitten_App_Frontend.Services
{
    public class PostsService
    {
        private readonly HttpClient _httpClient; //HTTPClient für die Kommunikation mit unserem Backend
        private readonly string _baseUrl = "https://unserBackend:3000/events/"; //unsere URL vom Backend auf der die Daten bereitgestellt werden

        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public PostsService()
        {
        }

        // Alle Posts abrufen
        public async Task<List<Posts>> GetAllPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Posts>>(_baseUrl);
        }

        // Einzelnen Post abrufen
        public async Task<Posts> GetPostByIdAsync(int postId)
        {
            return await _httpClient.GetFromJsonAsync<Posts>($"{_baseUrl}/{postId}");
        }

        // Neuen Post hinzufügen
        public async Task<bool> AddPostAsync(Posts post)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, post);
            return response.IsSuccessStatusCode;
        }

        // Post aktualisieren
        public async Task<bool> UpdatePostAsync(Posts post)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{post.PostID}", post);
            return response.IsSuccessStatusCode;
        }

        // Post löschen
        public async Task<bool> DeletePostAsync(int postId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{postId}");
            return response.IsSuccessStatusCode;
        }
    }
}
