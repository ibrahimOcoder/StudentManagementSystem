using AutoMapper;
using StudentManagementSystem.Admin.Entities;
using StudentManagementSystem.Admin.Models;

namespace StudentManagementSystem.Admin.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile() 
        {
            CreateMap<StudentCreateDto, Student>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.StudentEmail));
        }
    }
}
