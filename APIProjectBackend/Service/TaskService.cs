using APIProjectBackend.Entities;
using APIProjectBackend.EntityFrameworkRepository.Contracts;
using APIProjectBackend.Service.Contracts;

namespace APIProjectBackend.Service
{
    public class TaskService : BaseService<Entities.Task>, ITaskService
    {
        public TaskService(IBaseEntityFrameworkRepository<Entities.Task> repository) : base(repository)
        {
        }
    }
}
