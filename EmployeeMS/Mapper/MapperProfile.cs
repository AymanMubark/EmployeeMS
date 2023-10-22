using AutoMapper;
using EmployeeMS.Data.Entities;
using EmployeeMS.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeMS.Mapper
{

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PagedList<Employee>, PagedList<EmployeeOutputDto>>().ReverseMap();
            CreateMap<EmployeeInputDto, Employee>().ForMember(dest => dest.Photo, opt => opt.Ignore()).ReverseMap();
            CreateMap<IdentityUser, UserOutputDto>().
                ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.UserName)); 
            CreateMap<Department, DepartmentOutputDto>().ReverseMap();
            CreateMap<Employee, EmployeeOutputDto>().ReverseMap();
        }
    }
}
