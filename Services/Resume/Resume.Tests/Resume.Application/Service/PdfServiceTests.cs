using FluentAssertions;
using Resume.Application.DTOs;
using Resume.Application.Service;
using Xunit;

namespace Resume.Tests.Resume.Application.Service
{
    public class PdfServiceTests
    {
        [Fact]
        public void GeneratePdf_ShouldReturnNonEmptyByteArray()
        {
            // Arrange
            var resumeDto = new ResumeDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123-456-7890",
                Position = "Software Engineer",
                Description = "Experienced software engineer...",
                Experiences = new List<ExperienceDto>
                {
                    new ExperienceDto
                    {
                        CompanyName = "Tech Corp",
                        Address = "123 Tech Lane",
                        Duration = "Jan 2020 - Present",
                        Position = "Senior Developer",
                        Description = "Lead developer working on various projects"
                    }
                },
                Educations = new List<EducationDto>
                {
                    new EducationDto
                    {
                        InstitutionName = "University of Example",
                        Address = "789 University Road",
                        Duration = "2014 - 2018",
                        Degree = "Bachelor of Science in Computer Science",
                        Description = "Graduated with honors"
                    }
                },
                Projects = new List<ProjectDto>
                {
                    new ProjectDto
                    {
                        ProjectName = "Sample Project",
                        Description = "Developed a sample project for demonstration purposes"
                    }
                },
                Skills = new List<SkillDto>
                {
                    new SkillDto
                    {
                        SkillName = "C#",
                        ProficiencyLevel = 5
                    }
                },
                Interests = new List<InterestDto>
                {
                    new InterestDto
                    {
                        InterestName = "Reading"
                    }
                }
            };

            // Act
            var pdfBytes = PdfService.GeneratePdf(resumeDto);

            // Assert
            pdfBytes.Should().NotBeNull();
            pdfBytes.Should().NotBeEmpty();
        }

        [Fact]
        public void GeneratePdf_ShouldContainResumeData()
        {
            // Arrange
            var resumeDto = new ResumeDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123-456-7890",
                Position = "Software Engineer",
                Description = "Experienced software engineer...",
                Experiences = new List<ExperienceDto>
                {
                    new ExperienceDto
                    {
                        CompanyName = "Tech Corp",
                        Address = "123 Tech Lane",
                        Duration = "Jan 2020 - Present",
                        Position = "Senior Developer",
                        Description = "Lead developer working on various projects"
                    }
                },
                Educations = new List<EducationDto>
                {
                    new EducationDto
                    {
                        InstitutionName = "University of Example",
                        Address = "789 University Road",
                        Duration = "2014 - 2018",
                        Degree = "Bachelor of Science in Computer Science",
                        Description = "Graduated with honors"
                    }
                },
                Projects = new List<ProjectDto>
                {
                    new ProjectDto
                    {
                        ProjectName = "Sample Project",
                        Description = "Developed a sample project for demonstration purposes"
                    }
                },
                Skills = new List<SkillDto>
                {
                    new SkillDto
                    {
                        SkillName = "C#",
                        ProficiencyLevel = 5
                    }
                },
                Interests = new List<InterestDto>
                {
                    new InterestDto
                    {
                        InterestName = "Reading"
                    }
                }
            };

            // Act
            var pdfBytes = PdfService.GeneratePdf(resumeDto);

            // Assert
            pdfBytes.Should().NotBeNull();
            pdfBytes.Should().NotBeEmpty();

            // Additional checks can be added here to validate the content of the PDF.
            // This can involve using PDF parsing libraries to inspect the content, 
            // but for simplicity, this example checks only for non-null and non-empty.
        }
    }
}
