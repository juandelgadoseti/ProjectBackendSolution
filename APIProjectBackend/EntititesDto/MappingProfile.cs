using APIProjectBackend.Entities;
using AutoMapper;

namespace APIProjectBackend.EntititesDto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Entities.Task, TaskDto>().ReverseMap();
        }
    }
}
