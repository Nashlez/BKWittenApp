using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models; 

namespace BKWitten_App_Frontend.Services
{
    internal class MediaServices
    {
        private readonly HttpClient _httpClient; 
        private readonly string _baseUrl = "http://10.32.0.156:5266/api/media"; 
        public MediaServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateMediaAsync(Media mediaData)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_baseUrl, mediaData);
            return response.IsSuccessStatusCode;
        }
        public async Task<List<Media>?> GetMediaAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Media>>(_baseUrl);
        }

        public async Task<Media?> GetMediaByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Media>($"{_baseUrl}/{id}");
        }
        public async Task<bool> UpdateMediaAsync(int id, Media updatedMedia)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", updatedMedia);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteMediaAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
