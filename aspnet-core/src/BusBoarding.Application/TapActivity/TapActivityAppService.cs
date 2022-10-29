using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using BusBoarding.Authorization;
using BusBoardingSystem.Domain;
using BusBoardingSystem.TagAS.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace BusBoardingSystem.TapActivityAS
{
    [AbpAuthorize(PermissionNames.Pages_People)]
    public class TapActivityAppService : ITapActivityAppService
    {
        public TapActivityAppService()
        {
        }
    }
}
