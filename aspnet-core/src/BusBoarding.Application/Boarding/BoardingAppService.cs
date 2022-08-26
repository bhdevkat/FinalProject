using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BusBoarding.Authorization;
using BusBoardingSystem.BoardingAS.Dto;
using BusBoardingSystem.Domain;

namespace BusBoardingSystem.BoardingAS
{
    [AbpAuthorize(PermissionNames.Pages_Boardings)]
    public class BoardingAppService : AsyncCrudAppService<Boarding, BoardingDto, int, PagedBoardingResultRequestDto, CreateBoardingDto, BoardingDto>, IBoardingAppService
    {            
        public BoardingAppService(IRepository<Boarding, int> repository) : base(repository)
        {
        }
    }
}
