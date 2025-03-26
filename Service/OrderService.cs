using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using framedart_project_frontend.Service.Interfaces;
using framedart_project_frontend.Models.GlobalModels;
using framedart_project_frontend.Models.Order;
using Microsoft.Extensions.Options;

namespace framedart_project_frontend.Service {
    public class OrderService : IOrderService {

        private readonly HttpClient _httpClient;

        public OrderService (HttpClient httpClient, IOptions<ApiSettings> apiSettings) {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<ApiResponse<string>> SubmitOrder (OrderRequestModel orderToSubmit) {
            try {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Order", orderToSubmit);
                response.EnsureSuccessStatusCode(); 

                string jsonResponse = await response.Content.ReadAsStringAsync();

                return new ApiResponse<string> {
                    Success = true,
                    Data = jsonResponse,
                    Message = "Order submitted successfully."
                };

            } catch (HttpRequestException httpEx) {
                return new ApiResponse<string> {
                    Success = false,
                    Data = null,
                    Message = $"HTTP error occurred: {httpEx.Message}"
                };

            } catch (Exception ex) {
                return new ApiResponse<string> {
                    Success = false,
                    Data = null,
                    Message = $"An unexpected error occurred: {ex.Message}"
                };
            }
        }
    }
}
