using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BusBoarding.Configuration;

namespace BusBoarding.Web.Host.Startup
{
    [DependsOn(
       typeof(BusBoardingWebCoreModule))]
    public class BusBoardingWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BusBoardingWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BusBoardingWebHostModule).GetAssembly());
        }
    }
}
