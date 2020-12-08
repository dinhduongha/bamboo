using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Bamboo.EntityFrameworkCore
{
    [DependsOn(
        typeof(BambooEntityFrameworkCoreModule)
        )]
    public class BambooEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BambooMigrationsDbContext>();
        }
    }
}
