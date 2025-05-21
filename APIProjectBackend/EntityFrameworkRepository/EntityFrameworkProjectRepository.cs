using APIProjectBackend.Data;
using APIProjectBackend.Entities;
using APIProjectBackend.EntityFrameworkRepository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace APIProjectBackend.EntityFrameworkRepository
{
    public class EntityFrameworkProjectRepository : BaseEntityFrameworkRepository<Project>, IEntityFrameworkProjectRepository
    {
        public EntityFrameworkProjectRepository(AppDbContext context) : base(context) {}
    }
}
