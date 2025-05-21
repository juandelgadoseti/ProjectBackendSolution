using APIProjectBackend.Entities;
using APIProjectBackend.EntititesDto;
using APIProjectBackend.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectBackend.Controllers
{

    [ApiController]
    [Route("project")]
    public class ProjectController : BaseController<Project, ProjectDto>
    {
        IProjectService _projectService;
        public ProjectController(IMapper mapper, IProjectService projectService) : base(mapper, projectService)
        {
            _projectService = projectService;
        }
    }
}
