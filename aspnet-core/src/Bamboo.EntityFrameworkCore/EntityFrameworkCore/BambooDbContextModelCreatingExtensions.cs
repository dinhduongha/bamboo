using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Bamboo.EntityFrameworkCore
{
    public static class BambooDbContextModelCreatingExtensions
    {
        public static void ConfigureBamboo(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BambooConsts.DbTablePrefix + "YourEntities", BambooConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

#if HAS_DB_POSTGRESQL
            builder.UseSerialColumns();
            // builder.StringSize();
            // builder.PostgreSQLDataType();
            // builder.SnakeCase();
            // Change to lower case:
            // https://github.com/abpframework/abp/issues/2131
#endif
        }
    }
}