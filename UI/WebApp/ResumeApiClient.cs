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

        public async Task<byte[]> GenerateResumeAsync(ResumeRequestDto resume)
        {
            var response = await _httpClient.PostAsJsonAsync("api/resume", resume);
            response.EnsureSuccessStatusCode(); // Throws an exception if the HTTP response is unsuccessful
            return await response.Content.ReadAsByteArrayAsync();
        }
        public async Task<List<MockTestDto>> GetMockTest(string skillName)
        {
            var response = await _httpClient.GetFromJsonAsync<MockTestDtoResponse>($"api/mockTest?skillName={skillName}");
            return response.Questions;
        }
    }
}