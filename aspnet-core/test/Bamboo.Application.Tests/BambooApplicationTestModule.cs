using Volo.Abp.Modularity;

namespace Bamboo
{
    [DependsOn(
        typeof(BambooApplicationModule),
        typeof(BambooDomainTestModule)
        )]
    public class BambooApplicationTestModule : AbpModule
    {

    }
}