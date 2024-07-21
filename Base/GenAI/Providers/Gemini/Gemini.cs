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

        public async Task<T> GenerateResponseObject<T>(string request) where T : DynamicResponse, new()
        {
            T t = new T();
            var sampleResponse = t.GetSampleInstance();
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

            GeminiResponse geminiResponse = JsonConvert.DeserializeObject<GeminiResponse>(await response.Content.ReadAsStringAsync());
            string jsonResponse = geminiResponse.candidates[0].content.parts[0].text.Replace("```", "").Replace("json\n", "").Trim();
            var responseObj = JsonConvert.DeserializeObject<List<T>>(jsonResponse);
            return responseObj.FirstOrDefault();
        }
    }
}
