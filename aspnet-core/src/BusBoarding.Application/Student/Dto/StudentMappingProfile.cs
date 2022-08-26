using AutoMapper;
using BusBoardingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.StudentAS.Dto
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<StudentDto, Student>();

            CreateMap<Student, StudentDto>();

            CreateMap<CreateStudentDto, Student>();

            CreateMap<CreateStudentDto, Person>();
        }
    }
}
