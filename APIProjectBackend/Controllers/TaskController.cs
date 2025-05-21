using APIProjectBackend.Entities;
using APIProjectBackend.EntititesDto;
using APIProjectBackend.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectBackend.Controllers
{
    [ApiController]
    [Route("task")]
    public class TaskController : BaseController<Entities.Task, TaskDto>
    {
        ITaskService _taskService;
        public TaskController(IMapper mapper, ITaskService taskService) : base(mapper, taskService)
        {
            _taskService = taskService;
        }
    }
}
