using Base.Domain;
using Resume.Application.DTOs;

namespace Resume.Infrastructure.Repositories.Interface
{
    public interface IResumeRepository : IRepository<Resume.Domain.Resume>
    {
        public Task<ResumeDto> GetByIdAsync(Guid resumeId);
    }
}
