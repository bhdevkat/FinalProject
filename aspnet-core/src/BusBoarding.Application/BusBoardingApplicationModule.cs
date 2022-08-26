using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BusBoarding.Authorization;

namespace BusBoarding
{
    [DependsOn(
        typeof(BusBoardingCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BusBoardingApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BusBoardingAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BusBoardingApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
