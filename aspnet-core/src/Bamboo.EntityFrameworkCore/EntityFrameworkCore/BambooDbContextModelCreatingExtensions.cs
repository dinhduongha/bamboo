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
        }
    }
}