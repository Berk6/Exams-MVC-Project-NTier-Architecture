using Exams.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Exams.WEB.Services
{
    public class QuestionApiService
    {
        private readonly HttpClient _httpClient;
        public QuestionApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<QuestionViewModel> CreateQuestion(QuestionViewModel questionMakerDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("question", questionMakerDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<QuestionViewModel>>();
                return responseBody.Data;
            }
            else
            {
                return null;
            }
        }
        public async Task<QuestionViewModel> DeleteQuestion(int id)
        {
            var response = await _httpClient.DeleteAsync($"question/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<QuestionViewModel>>();
                return responseBody.Data;
            }
            else
            {
                return null;
            }
        }
    }
}
