using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models; 

namespace BKWitten_App_Frontend.Services
{
    internal class EventsServices
    {
        private readonly HttpClient _httpClient; 
        private readonly string _baseUrl = "http://10.32.0.156:5266/api/bkw/events";
        public EventsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateEventAsync(Events eventData)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_baseUrl, eventData);
            return response.IsSuccessStatusCode;
        }
        public async Task<List<Events>> GetEventsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Events>>(_baseUrl) ?? new List<Events>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Events: {ex.Message}");
                return new List<Events>();
            }
        }
        public async Task<Events?> GetEventByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Events>($"{_baseUrl}/{id}");
        }
        public async Task<bool> UpdateEventAsync(int id, Events updatedEvent)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", updatedEvent);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteEventAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
        public static implicit operator EventsServices(MediaServices v)
        {
            throw new NotImplementedException();
        }
    }
}
