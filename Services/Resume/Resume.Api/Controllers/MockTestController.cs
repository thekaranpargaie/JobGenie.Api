using GenAI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTOs;

namespace Resume.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockTestController : ControllerBase
    {
        public readonly IGenAI _genAi;
        public MockTestController(IGenAI genAi)
        {
            _genAi = genAi;
        }
        [HttpGet]
        public async Task<MockTestDtoResponse> GenerateTest(string skillName)
        {
            string requestPrompt = $"Get 5 questions for following skill: {skillName}.";
            var genAiResponse = await _genAi.GenerateResponseObject<MockTestDtoResponse>(requestPrompt);
            return genAiResponse;
        }
    }
}
