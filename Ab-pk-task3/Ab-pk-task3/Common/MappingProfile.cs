using AutoMapper;
using Ab_pk_task3.BankAccountOperations.GetBA;
using Ab_pk_task3.Models;
using Ab_pk_task3.StudentsOperations.CreateStudent;
using Ab_pk_task3.StudentsOperations.GetStudentDetail;

namespace Ab_pk_task3.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateStudentModel, Student>();
            CreateMap<Student, StudentDetailViewModel>()
                .ForMember(dest => dest.Class, opt =>opt.MapFrom(src=>((ClassEnum)src.ClassId).ToString()))
                .ForMember(dest => dest.BookGenre, opt => opt.MapFrom(src => ((BookGenreEnum)src.BookGenreId).ToString()));
            CreateMap<Student, StudentViewModel>()
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => ((ClassEnum)src.ClassId).ToString()))
                .ForMember(dest => dest.BookGenre, opt => opt.MapFrom(src => ((BookGenreEnum)src.BookGenreId).ToString()));
        }
    }
}
