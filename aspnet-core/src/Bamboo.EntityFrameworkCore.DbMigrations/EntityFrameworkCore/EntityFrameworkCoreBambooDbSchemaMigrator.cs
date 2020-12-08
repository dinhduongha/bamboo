using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bamboo.Data;
using Volo.Abp.DependencyInjection;

namespace Bamboo.EntityFrameworkCore
{
    public class EntityFrameworkCoreBambooDbSchemaMigrator
        : IBambooDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreBambooDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the BambooMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<BambooMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}