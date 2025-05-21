using APIProjectBackend.Data;
using APIProjectBackend.Entities;
using APIProjectBackend.EntityFrameworkRepository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace APIProjectBackend.EntityFrameworkRepository
{
    public class EntityFrameworkTaskRepository : BaseEntityFrameworkRepository<Entities.Task>, IEntityFrameworkTaskRepository
    {
        private readonly AppDbContext _context;
        public EntityFrameworkTaskRepository(AppDbContext context) : base(context) { _context = context; }

        public async Task<List<Entities.Task>> GetTasksByProjectIdAsync(Guid projectId)
        {
            return await _context.Tasks
                .Where(t => t.IdProyecto == projectId)
                .ToListAsync();
        }
    }
}
