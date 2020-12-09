using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace Bamboo.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class BambooMigrationsDbContextFactory : IDesignTimeDbContextFactory<BambooMigrationsDbContext>
    {
        public BambooMigrationsDbContext CreateDbContext(string[] args)
        {
            BambooEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();
#if HAS_DB_POSTGRESQL
            var builder = new DbContextOptionsBuilder<BambooMigrationsDbContext>()
                .UseNpgsql(configuration.GetConnectionString("Default"), o => o.UseNetTopologySuite())
                //.ReplaceService<IMigrationsSqlGenerator, MyPostgresMigrationsSqlGenerator>()
                ;
#else
            var builder = new DbContextOptionsBuilder<BambooMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));
#endif
            return new BambooMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Bamboo.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
