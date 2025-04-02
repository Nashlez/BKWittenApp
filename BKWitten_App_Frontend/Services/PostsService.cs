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
        private readonly HttpClient _httpClient; 
        private readonly string _baseUrl = "http://10.32.0.156:5266/api/bkw/posts"; 
        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Posts>> GetAllPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Posts>>(_baseUrl);
        }
        public async Task<Posts> GetPostByIdAsync(int postId)
        {
            return await _httpClient.GetFromJsonAsync<Posts>($"{_baseUrl}/{postId}");
        }
        public async Task<bool> AddPostAsync(Posts post)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, post);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdatePostAsync(Posts post)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{post.PostID}", post);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeletePostAsync(int postId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{postId}");
            return response.IsSuccessStatusCode;
        }
    }
}
