using Abp.Application.Services;
using BusBoardingSystem.BusAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.BusAS 
{
    public interface IBusAppService : IAsyncCrudAppService<BusDto, int, PagedBusResultRequestDto, CreateBusDto, BusDto>
    {
    }
}
