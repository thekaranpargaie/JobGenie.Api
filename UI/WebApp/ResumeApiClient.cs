using Resume.Application.DTOs;

namespace WebApp
{
    internal class ResumeApiClient
    {
        private readonly HttpClient _httpClient;

        public ResumeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> GenerateResumeAsync(ResumeRequestDto resume)
        {
            return _httpClient.PostAsJsonAsync("api/resume", resume)
                               .ContinueWith(response => response.Result.Content.ReadAsStringAsync().Result);
        }
    }
}