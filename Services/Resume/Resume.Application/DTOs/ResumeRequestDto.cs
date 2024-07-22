using GenAI;
using Resume.Domain;

namespace Resume.Application.DTOs
{
    public class ResumeRequestDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Position { get; set; }
        public List<ExperienceRequestDto> Experiences { get; set; } = new List<ExperienceRequestDto>();
        public List<EducationRequestDto> Educations { get; set; } = new List<EducationRequestDto>();
        public List<ProjectRequestDto> Projects { get; set; } = new List<ProjectRequestDto>();
        public List<string> Skills { get; set; } = new List<string>();
        public List<string> Interests { get; set; } = new List<string>();
    }

    public class ExperienceRequestDto
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Duration { get; set; }
        public string Position { get; set; }
    }

    public class EducationRequestDto
    {
        public string InstitutionName { get; set; }
        public string Address { get; set; }
        public string Duration { get; set; }
        public string Degree { get; set; }
    }

    public class ProjectRequestDto
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }

    public class SkillRequestDto
    {
        public string SkillName { get; set; }
    }

    public class InterestRequestDto
    {
        public string InterestName { get; set; }
    }
}
