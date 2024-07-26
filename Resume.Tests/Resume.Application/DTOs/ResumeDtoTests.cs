using Xunit.Categories;
using Xunit;
using Resume.Tests.Resume.Application.DTOs.DTOsClass;
using FluentAssertions;

namespace Resume.Tests.Resume.Application.DTOs
{
    public class ResumeDtoTests
    {
        [Fact]
        [UnitTest]
        public void GetSampleInstance_ShouldReturnNonNullInstance()
        {
            // Arrange
            var response = new ResumeDtoResponse();

            // Act
            var result = response.GetSampleInstance();

            // Assert
            result.Should().NotBeNull();
            result.Resume.Should().NotBeNull();
        }

        [Fact]
        [UnitTest]
        public void GetSampleInstance_ShouldHaveCorrectProperties()
        {
            // Arrange
            var response = new ResumeDtoResponse();

            // Act
            var result = response.GetSampleInstance().Resume;

            // Assert
            result.Should().NotBeNull();
            result.FirstName.Should().Be("John");
            result.LastName.Should().Be("Doe");
            result.Email.Should().Be("john.doe@example.com");
            result.Phone.Should().Be("123-456-7890");
            result.Position.Should().Be("Software Engineer");
            result.Description.Should().Be("Experienced software engineer with a passion for developing innovative programs that expedite the efficiency and effectiveness of organizational success.");
        }

        [Fact]
        [UnitTest]
        public void GetSampleInstance_ShouldHaveExperiences()
        {
            // Arrange
            var response = new ResumeDtoResponse();

            // Act
            var result = response.GetSampleInstance().Resume;

            // Assert
            result.Should().NotBeNull();
            result.Experiences.Should().HaveCount(2);

            var firstExperience = result.Experiences.First();
            firstExperience.CompanyName.Should().Be("Tech Corp");
            firstExperience.Address.Should().Be("123 Tech Lane");
            firstExperience.Duration.Should().Be("Jan 2020 - Present");
            firstExperience.Position.Should().Be("Senior Developer");
            firstExperience.Description.Should().Be("Lead developer working on various projects");

            var secondExperience = result.Experiences.Last();
            secondExperience.CompanyName.Should().Be("Web Solutions");
            secondExperience.Address.Should().Be("456 Web Street");
            secondExperience.Duration.Should().Be("Jan 2018 - Dec 2019");
            secondExperience.Position.Should().Be("Developer");
            secondExperience.Description.Should().Be("Worked on web development projects");
        }

        [Fact]
        [UnitTest]
        public void GetSampleInstance_ShouldHaveEducations()
        {
            // Arrange
            var response = new ResumeDtoResponse();

            // Act
            var result = response.GetSampleInstance().Resume;

            // Assert
            result.Should().NotBeNull();
            result.Educations.Should().HaveCount(1);

            var education = result.Educations.First();
            education.InstitutionName.Should().Be("University of Example");
            education.Address.Should().Be("789 University Road");
            education.Duration.Should().Be("2014 - 2018");
            education.Degree.Should().Be("Bachelor of Science in Computer Science");
            education.Description.Should().Be("Graduated with honors");
        }

        [Fact]
        [UnitTest]
        public void GetSampleInstance_ShouldHaveProjects()
        {
            // Arrange
            var response = new ResumeDtoResponse();

            // Act
            var result = response.GetSampleInstance().Resume;

            // Assert
            result.Should().NotBeNull();
            result?.Projects.Should().HaveCount(1);

            var project = result.Projects.First();
            project.ProjectName.Should().Be("Sample Project");
            project.Description.Should().Be("Developed a sample project for demonstration purposes");
        }

        [Fact]
        [UnitTest]
        public void GetSampleInstance_ShouldHaveSkills()
        {
            // Arrange
            var response = new ResumeDtoResponse();

            // Act
            var result = response.GetSampleInstance().Resume;

            // Assert
            result.Should().NotBeNull();
            result.Skills.Should().HaveCount(2);

            var firstSkill = result.Skills.First();
            firstSkill.SkillName.Should().Be("C#");
            firstSkill.ProficiencyLevel.Should().Be(5);

            var secondSkill = result.Skills.Last();
            secondSkill.SkillName.Should().Be("Java");
            secondSkill.ProficiencyLevel.Should().Be(4);
        }

        [Fact]
        [UnitTest]
        public void GetSampleInstance_ShouldHaveInterests()
        {
            // Arrange
            var response = new ResumeDtoResponse();

            // Act
            var result = response.GetSampleInstance().Resume;

            // Assert
            result.Should().NotBeNull();
            result.Interests.Should().HaveCount(2);

            var firstInterest = result.Interests.First();
            firstInterest.InterestName.Should().Be("Reading");

            var secondInterest = result.Interests.Last();
            secondInterest.InterestName.Should().Be("Hiking");
        }
    }
}
