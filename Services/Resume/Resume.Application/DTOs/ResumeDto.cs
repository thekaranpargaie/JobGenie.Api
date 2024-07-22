using GenAI;
using Resume.Domain;

namespace Resume.Application.DTOs
{
    public class ResumeDtoResponse : DynamicResponse
    {
        public ResumeDto Resume { get; set; }
        public override ResumeDtoResponse GetSampleInstance()
        {
            var sampleResume = new ResumeDto(new Domain.Resume
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123-456-7890",
                Position = "Software Engineer",
                Description = "Experienced software engineer with a passion for developing innovative programs that expedite the efficiency and effectiveness of organizational success.",
                Experiences = new List<Experience>
            {
                new Experience
                {
                    CompanyName = "Tech Corp",
                    Address = "123 Tech Lane",
                    Duration = "Jan 2020 - Present",
                    Position = "Senior Developer",
                    Description = "Lead developer working on various projects",
                    ResumeId = Guid.NewGuid()
                },
                new Experience
                {
                    CompanyName = "Web Solutions",
                    Address = "456 Web Street",
                    Duration = "Jan 2018 - Dec 2019",
                    Position = "Developer",
                    Description = "Worked on web development projects",
                    ResumeId = Guid.NewGuid()
                }
            },
                Educations = new List<Education>
            {
                new Education
                {
                    InstitutionName = "University of Example",
                    Address = "789 University Road",
                    Duration = "2014 - 2018",
                    Degree = "Bachelor of Science in Computer Science",
                    Description = "Graduated with honors",
                    ResumeId = Guid.NewGuid()
                }
            },
                Projects = new List<Project>
            {
                new Project
                {
                    ProjectName = "Sample Project",
                    Description = "Developed a sample project for demonstration purposes",
                    ResumeId = Guid.NewGuid()
                }
            },
                Skills = new List<Skill>
            {
                new Skill
                {
                    SkillName = "C#",
                    ProficiencyLevel = 5,
                    ResumeId = Guid.NewGuid()
                },
                new Skill
                {
                    SkillName = "Java",
                    ProficiencyLevel = 4,
                    ResumeId = Guid.NewGuid()
                }
            },
                Interests = new List<Interest>
            {
                new Interest
                {
                    InterestName = "Reading",
                    ResumeId = Guid.NewGuid()
                },
                new Interest
                {
                    InterestName = "Hiking",
                    ResumeId = Guid.NewGuid()
                }
            }
            });

            return new ResumeDtoResponse { Resume = sampleResume };
        }
    }
    public class ResumeDto: DynamicResponse
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
        public ResumeDto()
        {

        }
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
        public ExperienceDto()
        {

        }
        public ExperienceDto(Experience experience)
        {
            CompanyName = experience.CompanyName;
            Address = experience.Address;
            Duration = experience.Duration;
            Position = experience.Position;
            Description = experience.Description;
        }
    }

    public class EducationDto
    {
        public string InstitutionName { get; set; }
        public string Address { get; set; }
        public string Duration { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }
        public EducationDto()
        {

        }
        public EducationDto(Education education)
        {
            InstitutionName = education.InstitutionName;
            Address = education.Address;
            Duration = education.Duration;
            Degree = education.Degree;
            Description = education.Description;
        }
    }

    public class ProjectDto
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public ProjectDto()
        {

        }
        public ProjectDto(Project project)
        {
            ProjectName = project.ProjectName;
            Description = project.Description;
        }
    }

    public class SkillDto
    {
        public string SkillName { get; set; }
        public int ProficiencyLevel { get; set; } // Proficiency level from 1 to 5

        public SkillDto()
        {

        }
        public SkillDto(Skill skill)
        {
            SkillName = skill.SkillName;
            ProficiencyLevel = skill.ProficiencyLevel;
        }
    }

    public class InterestDto
    {
        public string InterestName { get; set; }
        public InterestDto()
        {

        }
        public InterestDto(Interest interest)
        {
            InterestName = interest.InterestName;
        }
    }

}
