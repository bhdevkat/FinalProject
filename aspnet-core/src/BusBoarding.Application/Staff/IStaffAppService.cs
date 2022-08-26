using Abp.Application.Services;
using BusBoardingSystem.StaffAS.Dto;

namespace BusBoardingSystem.StaffAS
{
    public interface IStaffAppService : IAsyncCrudAppService<StaffDto, int, PagedStaffResultRequestDto, CreateStaffDto, StaffDto>
    {
    }
}
