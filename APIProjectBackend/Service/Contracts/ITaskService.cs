using APIProjectBackend.Entities;
using System.Threading.Tasks;

namespace APIProjectBackend.Service.Contracts
{
    public interface ITaskService : IBaseService<Entities.Task>
    {
        public Task<List<Entities.Task>> GetByProjectIdAsync(Guid projectId);
    }
}
