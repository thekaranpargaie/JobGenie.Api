using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace GenAI.Providers.Gemini
{
    public class Gemini : IGenAI
    {
        private readonly HttpClient _geminiClient;
        private readonly string _geminiApiKey;
        public Gemini(IOptions<GeminiConfig> config)
        {
            _geminiApiKey = config.Value.ApiKey;
            _geminiClient = new HttpClient();
        }

        public async Task<GenAIResponse<TResponse>> GenerateResponseObject<TResponse>(string request)
        {
            // Create a sample instance of TResponse to generate the JSON schema
            var sampleResponse = Activator.CreateInstance<TResponse>();
            var sampleResponseJson = JsonConvert.SerializeObject(sampleResponse);

            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new
                        {
                            text = $"{request}. Response should be in following JSON Format: [{sampleResponseJson}]"
                        }
                    }
                }
            }
            };

            var jsonString = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _geminiClient.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={_geminiApiKey}", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<GenAIResponse<TResponse>>(responseString);
            return responseObj;
        }
    }
}
