using APIProjectBackend.Entities;
using APIProjectBackend.EntityFrameworkRepository.Contracts;
using APIProjectBackend.Service.Contracts;

namespace APIProjectBackend.Service
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        public ProjectService(IBaseEntityFrameworkRepository<Project> repository) : base(repository)
        {
        }
    }
}
