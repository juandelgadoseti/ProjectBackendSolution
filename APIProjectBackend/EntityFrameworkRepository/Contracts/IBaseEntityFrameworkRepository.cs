namespace APIProjectBackend.EntityFrameworkRepository.Contracts
{
    public interface IBaseEntityFrameworkRepository<T>
    {       
        public Task<IEnumerable<T>> GetAllAsync();
        
        public Task<T?> GetByIdAsync(Guid id);
       
        public Task<bool> DeleteByIdAsync(Guid id);
       
        public Task<T> SaveAsync(T entity);
       
        public Task<bool> UpdateAsync(T entity);
    }
}
