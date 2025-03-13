using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BKWitten_App_Frontend.Models; // Importiere die Events-Klasse

namespace BKWitten_App_Frontend.Services
{
    internal class EventsServices
    {
        private readonly HttpClient _httpClient; //HTTPClient für die Kommunikation mit unserem Backend
        private readonly string _baseUrl = "https://unserBackend:3000/events/"; //unsere URL vom Backend auf der die Daten bereitgestellt werden

        public EventsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public EventsServices()
        {
        }

        // Erstelle (POST) ein Event
        public async Task<bool> CreateEventAsync(Events eventData)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_baseUrl, eventData);
            return response.IsSuccessStatusCode;
        }

        // Lese (GET) alle vorhandenen Events
        public async Task<List<Events>?> GetEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Events>>(_baseUrl);
        }
        // Lese (GET) ein vorhandenes Event mit einer bestimmten EventID
        public async Task<Events?> GetEventByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Events>($"{_baseUrl}/{id}");
        }

        // Update (PUT) vorhandenes Event mit einer übergebenen EventID
        public async Task<bool> UpdateEventAsync(int id, Events updatedEvent)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", updatedEvent);
            return response.IsSuccessStatusCode;
        }

        // Lösche (DELETE) ein Event mit einer übergebenen EventID
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
