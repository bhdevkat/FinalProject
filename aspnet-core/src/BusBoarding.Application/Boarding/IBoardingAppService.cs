using Abp.Application.Services;
using BusBoardingSystem.BoardingAS.Dto;

namespace BusBoardingSystem.BoardingAS
{
    public interface IBoardingAppService : IAsyncCrudAppService<BoardingDto, int, PagedBoardingResultRequestDto, CreateBoardingDto, BoardingDto>
    {
    }
}
