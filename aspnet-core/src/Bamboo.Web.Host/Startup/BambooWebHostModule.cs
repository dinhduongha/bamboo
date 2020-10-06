using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Bamboo.Configuration;
using Bamboo.Base;

namespace Bamboo.Web.Host.Startup
{
    [DependsOn(
       typeof(BambooWebCoreModule),
       typeof(BambooBaseApplicationModule)
    )]
    public class BambooWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BambooWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooWebHostModule).GetAssembly());
        }
    }
}
