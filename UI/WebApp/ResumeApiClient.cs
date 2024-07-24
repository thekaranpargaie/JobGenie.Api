using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resume.Application.DTOs;

namespace WebApp
{
    internal class ResumeApiClient
    {
        private readonly HttpClient _httpClient;

        public ResumeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }
        public async Task<ResumeDto> GenerateResumeAsync(ResumeRequestDto resume)
        {
            var response = await _httpClient.PostAsJsonAsync("api/resume/generate", resume);
            string jsonResume = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResumeDto>(jsonResume);
        }
        public async Task<HttpResponseMessage> DownloadResumeAsync(ResumeDto resume)
        {
            var response = await _httpClient.PostAsJsonAsync("api/resume/download", resume);
            return response;
        }
        public async Task<List<MockTestDto>> GetMockTest(string skillName)
        {
            var response = await _httpClient.GetFromJsonAsync<MockTestDtoResponse>($"api/mockTest?skillName={skillName}");
            return response.Questions;
        }
    }
}