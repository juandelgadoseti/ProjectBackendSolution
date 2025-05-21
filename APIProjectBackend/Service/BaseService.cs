using APIProjectBackend.Entities;
using APIProjectBackend.EntityFrameworkRepository.Contracts;
using APIProjectBackend.Exceptions;
using APIProjectBackend.Service.Contracts;

namespace APIProjectBackend.Service
{
    public class BaseService<T> : IBaseService<T> where T : BDEntity
    {
        protected readonly IBaseEntityFrameworkRepository<T> _repository;

        public BaseService(IBaseEntityFrameworkRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository)); ;
        }
        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var allEntities = await _repository.GetAllAsync();
                return allEntities.ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error al obtener todas las entidades.", ex);
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException($"No se encontró la entidad con el ID {id}");

                return entity;
            }
            catch (Exception ex) when (ex is not NotFoundException)
            {
                throw new RepositoryException("Error al obtener la entidad por ID.", ex);
            }
        }

        public async Task<T> SaveAsync(T entity)
        {            
            if (entity == null)
                throw new ValidationException("La entidad no puede ser nula.");

            try
            {
                return await _repository.SaveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error al guardar la entidad.", ex);
            }
        }

        public async Task<T> SaveUpdateAsync(T entity)
        {
            if (entity == null)
                throw new ValidationException("La entidad no puede ser nula.");

            return entity.Id == null || entity.Id == Guid.Empty
                ? await  SaveAsync(entity)
                : await UpdateAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ValidationException("La entidad no puede ser nula.");

            try
            {
                var updated = await _repository.UpdateAsync(entity);
                if (!updated)
                    throw new UpdateConflictException($"No se pudo actualizar. Entidad con ID {entity.Id} no encontrada.");

                return entity;
            }
            catch (Exception ex) when (ex is not UpdateConflictException)
            {
                throw new RepositoryException("Error al actualizar la entidad.", ex);
            }
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    throw new NotFoundException($"No se puede eliminar. Entidad con ID {id} no encontrada.");

                var deleted = await _repository.DeleteByIdAsync(id);
                if (!deleted)
                    throw new DeleteException("Error inesperado al intentar eliminar la entidad.");

                return true;
            }
            catch (Exception ex) when (ex is not NotFoundException && ex is not DeleteException)
            {
                throw new RepositoryException("Error al eliminar la entidad.", ex);
            }
        }
    }
}
