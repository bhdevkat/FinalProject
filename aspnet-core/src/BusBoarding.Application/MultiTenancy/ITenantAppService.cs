using Abp.Application.Services;
using BusBoarding.MultiTenancy.Dto;

namespace BusBoarding.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

