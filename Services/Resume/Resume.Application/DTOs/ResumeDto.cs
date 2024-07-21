using Resume.Domain;

namespace Resume.Application.DTOs
{
    public class ResumeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public List<ExperienceDto> Experiences { get; set; } = new List<ExperienceDto>();
        public List<EducationDto> Educations { get; set; } = new List<EducationDto>();
        public List<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
        public List<SkillDto> Skills { get; set; } = new List<SkillDto>();
        public List<InterestDto> Interests { get; set; } = new List<InterestDto>();

        public ResumeDto(Domain.Resume resume)
        {
            FirstName = resume.FirstName;
            LastName = resume.LastName;
            Email = resume.Email;
            Phone = resume.Phone;
            Position = resume.Position;
            Description = resume.Description;
            Experiences = resume.Experiences.Select(e => new ExperienceDto(e)).ToList();
            Educations = resume.Educations.Select(e => new EducationDto(e)).ToList();
            Projects = resume.Projects.Select(p => new ProjectDto(p)).ToList();
            Skills = resume.Skills.Select(s => new SkillDto(s)).ToList();
            Interests = resume.Interests.Select(i => new InterestDto(i)).ToList();
        }
    }

    public class ExperienceDto
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Duration { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public Guid ResumeId { get; set; }

        public ExperienceDto(Experience experience)
        {
            CompanyName = experience.CompanyName;
            Address = experience.Address;
            Duration = experience.Duration;
            Position = experience.Position;
            Description = experience.Description;
            ResumeId = experience.ResumeId;
        }
    }

    public class EducationDto
    {
        public string InstitutionName { get; set; }
        public string Address { get; set; }
        public string Duration { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }
        public Guid ResumeId { get; set; }

        public EducationDto(Education education)
        {
            InstitutionName = education.InstitutionName;
            Address = education.Address;
            Duration = education.Duration;
            Degree = education.Degree;
            Description = education.Description;
            ResumeId = education.ResumeId;
        }
    }

    public class ProjectDto
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public Guid ResumeId { get; set; }

        public ProjectDto(Project project)
        {
            ProjectName = project.ProjectName;
            Description = project.Description;
            ResumeId = project.ResumeId;
        }
    }

    public class SkillDto
    {
        public string SkillName { get; set; }
        public int ProficiencyLevel { get; set; } // Proficiency level from 1 to 5
        public Guid ResumeId { get; set; }

        public SkillDto(Skill skill)
        {
            SkillName = skill.SkillName;
            ProficiencyLevel = skill.ProficiencyLevel;
            ResumeId = skill.ResumeId;
        }
    }

    public class InterestDto
    {
        public string InterestName { get; set; }
        public Guid ResumeId { get; set; }

        public InterestDto(Interest interest)
        {
            InterestName = interest.InterestName;
            ResumeId = interest.ResumeId;
        }
    }

}
