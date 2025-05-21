using Microsoft.AspNetCore.Mvc;

namespace APIProjectBackend.Controllers.Contracts
{
    public interface IBaseController<T> where T : class
    {        
        public Task<ActionResult<List<T>>> GetAllAsync();
        
        public Task<ActionResult<T>> GetByIdAsync(Guid id);
      
        public Task<ActionResult<T>> SaveEntityAsync(T entity);
        
        public Task<ActionResult<T>> UpdateEntityAsync(T entity);
        public Task<IActionResult> DeleteEntityAsync(Guid id);
    }
}
