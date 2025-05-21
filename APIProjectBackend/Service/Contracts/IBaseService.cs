using Microsoft.AspNetCore.Mvc;

namespace APIProjectBackend.Service.Contracts
{
    public interface IBaseService<T> where T : class
    { 
        public Task<T> GetByIdAsync(Guid id);      
        public Task<List<T>> GetAllAsync();      
        public Task<T> UpdateAsync(T entity);        
        public Task<T> SaveAsync(T entity);       
        public Task<T> SaveUpdateAsync(T entity);
        public Task<bool> DeleteByIdAsync(Guid id);
    }
}
