using Base.Domain;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume.Application.DTOs;
using Resume.Infrastructure.Configuration.DataAccess.Repository;
using Resume.Infrastructure.Repositories.Interface;
using Resume.Domain;

namespace Resume.Infrastructure.Repositories.Implementation
{
    public class ResumeRepository : Repository<Domain.Resume>, IResumeRepository
    {
        public ResumeRepository(ResumeDb dbContext) : base(dbContext)
        {
        }

        public async Task<ResumeDto> GetByIdAsync(Guid resumeId)
        {
            return await Table
                .Include(x => x.Skills)
                .Include(x=>x.Educations)
                .Include(x=>x.Experiences)
                .Include(x=>x.Interests)
                .Include(x=>x.Projects)
                .FirstOrDefaultAsync(x => x.Id == resumeId)
                .Select(x => new ResumeDto(x));
        }
        public async Task AddAsync(ResumeDto resumeDto)
        {
            var resume = new Domain.Resume
            {
                FirstName = resumeDto.FirstName,
                LastName = resumeDto.LastName,
                Email = resumeDto.Email,
                Phone = resumeDto.Phone,
                Position = resumeDto.Position,
                Description = resumeDto.Description,
                // Add other properties as needed
            };

            // Add related entities
            foreach (var experienceDto in resumeDto.Experiences)
            {
                resume.Experiences.Add(new Experience
                {
                    CompanyName = experienceDto.CompanyName,
                    Address = experienceDto.Address,
                    Duration = experienceDto.Duration,
                    Position = experienceDto.Position,
                    Description = experienceDto.Description
                });
            }

            foreach (var educationDto in resumeDto.Educations)
            {
                resume.Educations.Add(new Education
                {
                    InstitutionName = educationDto.InstitutionName,
                    Address = educationDto.Address,
                    Duration = educationDto.Duration,
                    Degree = educationDto.Degree,
                    Description = educationDto.Description
                });
            }

            foreach (var projectDto in resumeDto.Projects)
            {
                resume.Projects.Add(new Project
                {
                    ProjectName = projectDto.ProjectName,
                    Description = projectDto.Description
                });
            }

            foreach (var skillDto in resumeDto.Skills)
            {
                resume.Skills.Add(new Skill
                {
                    SkillName = skillDto.SkillName,
                    ProficiencyLevel = skillDto.ProficiencyLevel
                });
            }

            foreach (var interestDto in resumeDto.Interests)
            {
                resume.Interests.Add(new Interest
                {
                    InterestName = interestDto.InterestName
                });
            }

            await SaveAsync(resume);
        }

        public async Task UpdateAsync(Guid resumeId, ResumeDto resumeDto)
        {
            var resume = await Table
                .Include(x => x.Skills)
                .Include(x => x.Educations)
                .Include(x => x.Experiences)
                .Include(x => x.Interests)
                .Include(x => x.Projects)
                .FirstOrDefaultAsync(x => x.Id == resumeId);

            if (resume == null)
            {
                throw new KeyNotFoundException("Resume not found.");
            }

            // Update properties
            resume.FirstName = resumeDto.FirstName;
            resume.LastName = resumeDto.LastName;
            resume.Email = resumeDto.Email;
            resume.Phone = resumeDto.Phone;
            resume.Position = resumeDto.Position;
            resume.Description = resumeDto.Description;

            // Update related entities
            // Clear existing entities
            resume.Experiences.Clear();
            resume.Educations.Clear();
            resume.Projects.Clear();
            resume.Skills.Clear();
            resume.Interests.Clear();

            // Add updated entities
            foreach (var experienceDto in resumeDto.Experiences)
            {
                resume.Experiences.Add(new Experience
                {
                    CompanyName = experienceDto.CompanyName,
                    Address = experienceDto.Address,
                    Duration = experienceDto.Duration,
                    Position = experienceDto.Position,
                    Description = experienceDto.Description
                });
            }

            foreach (var educationDto in resumeDto.Educations)
            {
                resume.Educations.Add(new Education
                {
                    InstitutionName = educationDto.InstitutionName,
                    Address = educationDto.Address,
                    Duration = educationDto.Duration,
                    Degree = educationDto.Degree,
                    Description = educationDto.Description
                });
            }

            foreach (var projectDto in resumeDto.Projects)
            {
                resume.Projects.Add(new Project
                {
                    ProjectName = projectDto.ProjectName,
                    Description = projectDto.Description
                });
            }

            foreach (var skillDto in resumeDto.Skills)
            {
                resume.Skills.Add(new Skill
                {
                    SkillName = skillDto.SkillName,
                    ProficiencyLevel = skillDto.ProficiencyLevel
                });
            }

            foreach (var interestDto in resumeDto.Interests)
            {
                resume.Interests.Add(new Interest
                {
                    InterestName = interestDto.InterestName
                });
            }

            await SaveAsync(resume);
        }
    }
}
