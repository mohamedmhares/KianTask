using AutoMapper;
using Kian.task.Core.Entities;
using Kian.Task.Presentation.Dtos;

namespace Kian.Task.Presentation.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee , EmployeeDto>().ReverseMap();
        }
    }
}
