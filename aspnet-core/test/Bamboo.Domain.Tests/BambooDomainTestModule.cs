using Bamboo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bamboo
{
    [DependsOn(
        typeof(BambooEntityFrameworkCoreTestModule)
        )]
    public class BambooDomainTestModule : AbpModule
    {

    }
}