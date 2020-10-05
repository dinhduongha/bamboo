using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Bamboo.Authorization;

namespace Bamboo
{
    [DependsOn(
        typeof(BambooCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BambooApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BambooAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BambooApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
