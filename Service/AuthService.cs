using framedart_project_frontend.Service.Interfaces;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace framedart_project_frontend.Service {

    public class AuthService : IAuthService {

        private readonly HttpClient _httpClient;

        public AuthService (HttpClient httpClient, IOptions<ApiSettings> apiSettings) {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl);
        }

        public async Task<bool> Authenticate (string username, string password) {
            
            var response = await _httpClient.PostAsJsonAsync("Account/Login", new {
                Username = username,
                Password = password
            });

            return response.IsSuccessStatusCode;
        }
    }
}
