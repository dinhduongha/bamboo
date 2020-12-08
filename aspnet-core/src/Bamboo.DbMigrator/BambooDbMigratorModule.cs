using Bamboo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Bamboo.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BambooEntityFrameworkCoreDbMigrationsModule),
        typeof(BambooApplicationContractsModule)
        )]
    public class BambooDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
