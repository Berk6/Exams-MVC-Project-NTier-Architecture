using Exams.Core.DTOs;

namespace Exams.WEB.Services
{
    public class LoginApiService
    {
        private readonly HttpClient _httpClient;

        public LoginApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LoginDTO> Login(LoginDTO loginDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("login", loginDTO);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<LoginDTO>>();
            return responseBody.Data;
        }
    }
}
