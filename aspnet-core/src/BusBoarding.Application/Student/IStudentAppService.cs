using Abp.Application.Services;
using BusBoardingSystem.StudentAS.Dto;

namespace BusBoardingSystem.StudentAS
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>
    {       
    }
}
