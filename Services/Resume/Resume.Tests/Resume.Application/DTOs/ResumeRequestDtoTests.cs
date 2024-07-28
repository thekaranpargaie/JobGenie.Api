using Xunit.Categories;
using Xunit;
using Resume.Tests.Resume.Application.DTOs.DTOsClass;
using FluentAssertions;

namespace Resume.Tests.Resume.Application.DTOs
{
    public class ResumeRequestDtoTests
    {
        [Fact]
        [UnitTest]
        public void ResumeRequestDto_ShouldInitializeWithEmptyCollections()
        {
            // Arrange & Act
            var resumeRequest = new ResumeRequestDto();

            // Assert
            resumeRequest.Experiences.Should().BeEmpty();
            resumeRequest.Educations.Should().BeEmpty();
            resumeRequest.Projects.Should().BeEmpty();
            resumeRequest.Skills.Should().BeEmpty();
            resumeRequest.Interests.Should().BeEmpty();
        }

        [Fact]
        [UnitTest]
        public void ResumeRequestDto_ShouldSetAndGetProperties()
        {
            // Arrange
            var resumeRequest = new ResumeRequestDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123-456-7890",
                Position = "Software Engineer",
                Experiences = new List<ExperienceRequestDto>
                {
                    new ExperienceRequestDto
                    {
                        CompanyName = "Tech Corp",
                        Address = "123 Tech Lane",
                        Duration = "Jan 2020 - Present",
                        Position = "Senior Developer"
                    }
                },
                Educations = new List<EducationRequestDto>
                {
                    new EducationRequestDto
                    {
                        InstitutionName = "University of Example",
                        Address = "789 University Road",
                        Duration = "2014 - 2018",
                        Degree = "Bachelor of Science in Computer Science"
                    }
                },
                Projects = new List<ProjectRequestDto>
                {
                    new ProjectRequestDto
                    {
                        ProjectName = "Sample Project",
                        Description = "Developed a sample project for demonstration purposes"
                    }
                },
                Skills = new List<string> { "C#", "Java" },
                Interests = new List<string> { "Reading", "Hiking" }
            };

            // Act & Assert
            resumeRequest.FirstName.Should().Be("John");
            resumeRequest.LastName.Should().Be("Doe");
            resumeRequest.Email.Should().Be("john.doe@example.com");
            resumeRequest.Phone.Should().Be("123-456-7890");
            resumeRequest.Position.Should().Be("Software Engineer");

            resumeRequest.Experiences.Should().HaveCount(1);
            var experience = resumeRequest.Experiences[0];
            experience.CompanyName.Should().Be("Tech Corp");
            experience.Address.Should().Be("123 Tech Lane");
            experience.Duration.Should().Be("Jan 2020 - Present");
            experience.Position.Should().Be("Senior Developer");

            resumeRequest.Educations.Should().HaveCount(1);
            var education = resumeRequest.Educations[0];
            education.InstitutionName.Should().Be("University of Example");
            education.Address.Should().Be("789 University Road");
            education.Duration.Should().Be("2014 - 2018");
            education.Degree.Should().Be("Bachelor of Science in Computer Science");

            resumeRequest.Projects.Should().HaveCount(1);
            var project = resumeRequest.Projects[0];
            project.ProjectName.Should().Be("Sample Project");
            project.Description.Should().Be("Developed a sample project for demonstration purposes");

            resumeRequest.Skills.Should().Contain(new List<string> { "C#", "Java" });
            resumeRequest.Interests.Should().Contain(new List<string> { "Reading", "Hiking" });
        }

        [Fact]
        [UnitTest]
        public void ExperienceRequestDto_ShouldSetAndGetProperties()
        {
            // Arrange
            var experienceRequest = new ExperienceRequestDto
            {
                CompanyName = "Tech Corp",
                Address = "123 Tech Lane",
                Duration = "Jan 2020 - Present",
                Position = "Senior Developer"
            };

            // Act & Assert
            experienceRequest.CompanyName.Should().Be("Tech Corp");
            experienceRequest.Address.Should().Be("123 Tech Lane");
            experienceRequest.Duration.Should().Be("Jan 2020 - Present");
            experienceRequest.Position.Should().Be("Senior Developer");
        }

        [Fact]
        [UnitTest]
        public void EducationRequestDto_ShouldSetAndGetProperties()
        {
            // Arrange
            var educationRequest = new EducationRequestDto
            {
                InstitutionName = "University of Example",
                Address = "789 University Road",
                Duration = "2014 - 2018",
                Degree = "Bachelor of Science in Computer Science"
            };

            // Act & Assert
            educationRequest.InstitutionName.Should().Be("University of Example");
            educationRequest.Address.Should().Be("789 University Road");
            educationRequest.Duration.Should().Be("2014 - 2018");
            educationRequest.Degree.Should().Be("Bachelor of Science in Computer Science");
        }

        [Fact]
        [UnitTest]
        public void ProjectRequestDto_ShouldSetAndGetProperties()
        {
            // Arrange
            var projectRequest = new ProjectRequestDto
            {
                ProjectName = "Sample Project",
                Description = "Developed a sample project for demonstration purposes"
            };

            // Act & Assert
            projectRequest.ProjectName.Should().Be("Sample Project");
            projectRequest.Description.Should().Be("Developed a sample project for demonstration purposes");
        }

        [Fact]
        [UnitTest]
        public void SkillRequestDto_ShouldSetAndGetProperties()
        {
            // Arrange
            var skillRequest = new SkillRequestDto
            {
                SkillName = "C#"
            };

            // Act & Assert
            skillRequest.SkillName.Should().Be("C#");
        }

        [Fact]
        [UnitTest]
        public void InterestRequestDto_ShouldSetAndGetProperties()
        {
            // Arrange
            var interestRequest = new InterestRequestDto
            {
                InterestName = "Reading"
            };

            // Act & Assert
            interestRequest.InterestName.Should().Be("Reading");
        }
    }
}
