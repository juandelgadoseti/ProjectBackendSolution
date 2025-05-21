namespace APIProjectBackend.EntityFrameworkRepository.Contracts
{
    public interface IEntityFrameworkTaskRepository :IBaseEntityFrameworkRepository<Entities.Task>
    {
        public Task<List<Entities.Task>> GetTasksByProjectIdAsync(Guid projectId);
    }
}
