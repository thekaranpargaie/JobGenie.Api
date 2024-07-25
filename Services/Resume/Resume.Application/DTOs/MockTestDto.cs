using GenAI;

namespace Resume.Application.DTOs
{
    public class MockTestDtoResponse: DynamicResponse
    {
        public List<MockTestDto>? Questions { get; set; }
        public override dynamic GetSampleInstance()
        {
            MockTestDtoResponse response = new()
            {
                Questions =
            [
                new MockTestDto()
                {
                    Question = "Sample Questions.",
                    CorrectAnswer = 1,
                    Options=
                    [
                        new AnswerOptions()
                        {
                            Option = "Sample Option A",
                            OptionNumber = 1
                        }
                    ],
                    CorrectAnswerExplanation = "This is sample answer explanation, that gives reason behind answer."
                }
            ]
            };
            return response;
        }
    }
    public class MockTestDto
    {
        public string? Question { get; set; }
        public List<AnswerOptions>? Options {get;set; }
        public int CorrectAnswer { get; set; }
        public string? CorrectAnswerExplanation { get; set; }
    }
    public class AnswerOptions
    {
        public int OptionNumber { get; set; }
        public string? Option { get; set; }
    }
}
