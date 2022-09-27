using Exams.Core.DTOs;

namespace Exams.WEB.Services
{
    public class SignUpApiService
    {
        private readonly HttpClient _httpClient;

        public SignUpApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SignUpDTO> SignUp(SignUpDTO signUpDTO)
        {
            var response =await _httpClient.PostAsJsonAsync("signUp", signUpDTO);
            if (!response.IsSuccessStatusCode) return null /*response.StatusCode*/;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<SignUpDTO>>();
            return responseBody.Data;
        }
    }
}