using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BusBoarding.EntityFrameworkCore;
using BusBoarding.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BusBoarding.Web.Tests
{
    [DependsOn(
        typeof(BusBoardingWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BusBoardingWebTestModule : AbpModule
    {
        public BusBoardingWebTestModule(BusBoardingEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BusBoardingWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BusBoardingWebMvcModule).Assembly);
        }
    }
}