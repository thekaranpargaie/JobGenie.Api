using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Providers
{
    public class Gemini : IGenAI
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey;

        public Gemini(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<GenAIResponse<TResponse>> GenerateQuestionsAsync<TResponse>(string request)
        {
            // Create a sample instance of TResponse to generate the JSON schema
            var sampleResponse = Activator.CreateInstance<TResponse>();
            var sampleResponseJson = Json.SerializeObject(sampleResponse);

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
                            //text = $"Give me 5 questions for the following skill {request.Skill}, Response should be using this Json format. Nothing else: [{sampleResponseJson}]"
                        }
                    }
                }
            }
            };

            var jsonString = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var questionResponses = JsonConvert.DeserializeObject<GenAIResponse<TResponse>>(responseString);
            return questionResponses;
        }
    }
}
