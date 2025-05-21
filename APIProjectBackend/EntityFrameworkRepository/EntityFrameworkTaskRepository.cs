using APIProjectBackend.Data;
using APIProjectBackend.Entities;
using APIProjectBackend.EntityFrameworkRepository.Contracts;

namespace APIProjectBackend.EntityFrameworkRepository
{
    public class EntityFrameworkTaskRepository : BaseEntityFrameworkRepository<Entities.Task>, IEntityFrameworkTaskRepository
    {
        public EntityFrameworkTaskRepository(AppDbContext context) : base(context) { }
    }
}
