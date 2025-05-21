using APIProjectBackend.Data;
using APIProjectBackend.EntityFrameworkRepository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace APIProjectBackend.EntityFrameworkRepository
{
    public class BaseEntityFrameworkRepository<T> : IBaseEntityFrameworkRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public BaseEntityFrameworkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
