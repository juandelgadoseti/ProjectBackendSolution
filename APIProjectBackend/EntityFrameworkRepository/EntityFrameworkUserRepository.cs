using APIProjectBackend.Data;
using APIProjectBackend.Entities;
using APIProjectBackend.EntityFrameworkRepository.Contracts;

namespace APIProjectBackend.EntityFrameworkRepository
{
    public class EntityFrameworkUserRepository : BaseEntityFrameworkRepository<User>, IEntityFrameworkUserRepository
    {
        public EntityFrameworkUserRepository(AppDbContext context) : base(context) { }
    }
}
