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
        private readonly string _baseUrl = "http://10.32.0.156:5266/api/bkw/users"; 
        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Users>> GetAllUsersAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Users>>(_baseUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim abrufen der Lehrer/Benutzer");
            }
            return new List<Users>();
        }
        public async Task<Users> GetUserByIdAsync(int userId)
        {
            return await _httpClient.GetFromJsonAsync<Users>($"{_baseUrl}/{userId}");
        }
        public async Task<bool> RegisterUserAsync(Users user)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, user);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateUserAsync(Users user)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{user.UserID}", user);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{userId}");
            return response.IsSuccessStatusCode;
        }  
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
