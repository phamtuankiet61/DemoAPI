using AutoMapper;
using DemoAPI.DTOs.ClassRoom;
using DemoAPI.DTOs.Student;
using DemoAPI.Models;

namespace DemoAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(
                    dest => dest.ClassRoomName, 
                    opt => opt.MapFrom(src => src.ClassRoom != null ? src.ClassRoom.Name : "Chưa có lớp")
                );

            CreateMap<ClassRoom, ClassRoomDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<CreateClassRoomDto, ClassRoom>();

        }
    }
}
