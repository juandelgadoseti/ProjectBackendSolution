using APIProjectBackend.Entities;
using APIProjectBackend.EntititesDto;
using APIProjectBackend.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("task")]
    public class TaskController : BaseController<Entities.Task, TaskDto>
    {
        ITaskService _taskService;
        public TaskController(IMapper mapper, ITaskService taskService) : base(mapper, taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("byProjectId/{projectId}")]
        public async Task<ActionResult<List<TaskDto>>> GetByProjectId(Guid projectId)
        {
            var tasks = await _taskService.GetByProjectIdAsync(projectId);
            var dtos = _mapper.Map<List<TaskDto>>(tasks);
            return Ok(dtos);
        }
    }
}
