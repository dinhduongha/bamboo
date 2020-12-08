using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Data
{
    /* This is used if database provider does't define
     * IBambooDbSchemaMigrator implementation.
     */
    public class NullBambooDbSchemaMigrator : IBambooDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}