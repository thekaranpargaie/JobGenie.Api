using Base.Domain;

namespace Resume.Domain
{
    public class Resume : OperationLogEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<Education> Educations { get; set; } = new List<Education>();
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Interest> Interests { get; set; } = new List<Interest>();
    }

    public class Experience : OperationLogEntity
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Duration { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
    }

    public class Education : OperationLogEntity
    {
        public string InstitutionName { get; set; }
        public string Address { get; set; }
        public string Duration { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
    }

    public class Project : OperationLogEntity
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
    }

    public class Skill : OperationLogEntity
    {
        public string SkillName { get; set; }
        public int ProficiencyLevel { get; set; } // Proficiency level from 1 to 5
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
    }

    public class Interest : OperationLogEntity
    {
        public string InterestName { get; set; }
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
