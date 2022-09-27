using Exams.Core.DTOs;
using Exams.Core.Models;

namespace Exams.WEB.Services
{
    public class HomeApiService
    {
        private readonly HttpClient _httpClient;
        public HomeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HomeIndexDTO> Home(string userName)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<HomeIndexDTO>>($"home/{userName}");
            if (response.StatusCode != 200) return null;
            return response.Data;
              
        }
    }
}
