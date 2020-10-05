using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Bamboo.Configuration;
using Bamboo.Web;

namespace Bamboo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BambooDbContextFactory : IDesignTimeDbContextFactory<BambooDbContext>
    {
        public BambooDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BambooDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BambooDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BambooConsts.ConnectionStringName));

            return new BambooDbContext(builder.Options);
        }
    }
}
