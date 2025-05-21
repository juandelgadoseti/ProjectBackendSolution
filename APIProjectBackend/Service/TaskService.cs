using APIProjectBackend.Entities;
using APIProjectBackend.EntityFrameworkRepository.Contracts;
using APIProjectBackend.Exceptions;
using APIProjectBackend.Service.Contracts;

namespace APIProjectBackend.Service
{
    public class TaskService : BaseService<Entities.Task>, ITaskService
    {
        private readonly IEntityFrameworkTaskRepository _taskRepository;

        public TaskService(IEntityFrameworkTaskRepository taskRepository) : base(taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<Entities.Task>> GetByProjectIdAsync(Guid projectId)
        {
            var tasks = await _taskRepository.GetTasksByProjectIdAsync(projectId);

            if (tasks == null || !tasks.Any())
            {
                throw new NotFoundException($"No se encontraron tareas para el proyecto con ID: {projectId}");
            }

            return tasks;
        }
    }
}
