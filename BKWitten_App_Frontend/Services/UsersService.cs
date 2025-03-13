using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models;
namespace BKWitten_App_Frontend.Services
{
    public class UsersService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://unserBackend:3000/events/"; // API-URL anpassen

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public UsersService()
        {
            
        }
        // Alle Benutzer abrufen
        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Users>>(_baseUrl);
        }

        // Einzelnen Benutzer abrufen
        public async Task<Users> GetUserByIdAsync(int userId)
        {
            return await _httpClient.GetFromJsonAsync<Users>($"{_baseUrl}/{userId}");
        }

        // Benutzer registrieren (anlegen)
        public async Task<bool> RegisterUserAsync(Users user)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, user);
            return response.IsSuccessStatusCode;
        }

        // Benutzer aktualisieren
        public async Task<bool> UpdateUserAsync(Users user)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{user.UserID}", user);
            return response.IsSuccessStatusCode;
        }

        // Benutzer löschen
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{userId}");
            return response.IsSuccessStatusCode;
        }

        // Benutzeranmeldung (Login) unter Annahme das man sich mit Email und PW einloggen kann
        
        public async Task<Users> LoginAsync(string email, string password)
        {
            var loginData = new { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/login", loginData);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Users>();

            return null;
        }
    }
}
