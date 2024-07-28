using FluentAssertions;
using Xunit.Categories;
using Xunit;
using Resume.Tests.Resume.Application.DTOs.DTOsClass;

namespace Resume.Tests.Resume.Application.DTOs
{
    public class MockTestDtoTests
    {
        [Fact]
        [UnitTest]
        public void GetSampleInstance_ShouldReturnNonNullInstance()
        {
            // Arrange
            var response = new MockTestDtoResponse();

            // Act
            var result = response.GetSampleInstance();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        [UnitTest]
        public void GetSampleInstance_ShouldContainOneQuestion()
        {
            // Arrange
            var response = new MockTestDtoResponse();

            // Act
            var result = response.GetSampleInstance() as MockTestDtoResponse;

            // Assert
            result.Should().NotBeNull();
            result!.Questions.Should().HaveCount(1);
        }

        [Fact]
        [UnitTest]
        public void GetSampleInstance_QuestionShouldHaveCorrectProperties()
        {
            // Arrange
            var response = new MockTestDtoResponse();

            // Act
            var result = response.GetSampleInstance() as MockTestDtoResponse;

            // Assert
            result.Should().NotBeNull();
            var question = result!.Questions!.First();

            question.Question.Should().Be("Sample Questions.");
            question.CorrectAnswer.Should().Be(1);
            question.CorrectAnswerExplanation.Should().Be("This is sample answer explanation, that gives reason behind answer.");
        }

        [Fact]
        [UnitTest]
        public void GetSampleInstance_OptionsShouldHaveCorrectProperties()
        {
            // Arrange
            var response = new MockTestDtoResponse();

            // Act
            var result = response.GetSampleInstance() as MockTestDtoResponse;

            // Assert
            result.Should().NotBeNull();
            var question = result!.Questions!.First();
            var option = question.Options!.First();

            option.OptionNumber.Should().Be(1);
            option.Option.Should().Be("Sample Option A");
        }
    }
}
