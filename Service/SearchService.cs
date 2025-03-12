using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using framedart_project_frontend.Service.Interfaces;
using framedart_project_frontend.Models.GlobalModels;
using Microsoft.Extensions.Options;

namespace framedart_project_frontend.Service
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _httpClient;

        public SearchService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<ApiResponse<List<SearchResult>>> SearchCustomer (string text) {
            try {
                HttpResponseMessage response = await _httpClient.GetAsync($"Customer/search?text={text}");
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ApiResponse<List<SearchResult>>>(
                    jsonResponse,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

            } catch (Exception ex) {
                return new ApiResponse<List<SearchResult>> {
                    Success = false,
                    Message = $"Erro ao buscar clientes: {ex.Message}",
                    Data = new List<SearchResult>()
                };
            }
        }

        public async Task<ApiResponse<List<SearchResult>>> SearchMaterial (string text, string type) {
            try {
                HttpResponseMessage response = await _httpClient.GetAsync($"Material/search?text={text}&type={type}");
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ApiResponse<List<SearchResult>>>(
                    jsonResponse,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

            } catch (Exception ex) {
                return new ApiResponse<List<SearchResult>> {
                    Success = false,
                    Message = $"Erro ao buscar materiais: {ex.Message}",
                    Data = new List<SearchResult>()
                };
            }
        }
    }
}
