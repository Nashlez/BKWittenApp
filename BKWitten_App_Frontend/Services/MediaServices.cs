using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models; // Importiere die Events-Klasse

namespace BKWitten_App_Frontend.Services
{
    internal class MediaServices
    {
        private readonly HttpClient _httpClient; //HTTPClient für die Kommunikation mit unserem Backend
        private readonly string _baseUrl = "https://unserBackend:3000/events/"; //unsere URL vom Backend auf der die Daten bereitgestellt werden

        public MediaServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public MediaServices()
        {
        }

        // Erstelle (POST) eine Mediendatei
        public async Task<bool> CreateMediaAsync(Media mediaData)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_baseUrl, mediaData);
            return response.IsSuccessStatusCode;
        }

        // Lese die Medien in eine Liste ein
        public async Task<List<Media>?> GetMediaAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Media>>(_baseUrl);
        }

        public async Task<Media?> GetMediaByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Media>($"{_baseUrl}/{id}");
        }

        // Eine Mediendatei mit einer bestimmten übergebenen MedienID updaten
        public async Task<bool> UpdateMediaAsync(int id, Media updatedMedia)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", updatedMedia);
            return response.IsSuccessStatusCode;
        }

        // Eine Mediendatei mit einer bestimmten übergebenen MedienID löschen
        public async Task<bool> DeleteMediaAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
