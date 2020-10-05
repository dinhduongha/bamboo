using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Bamboo.EntityFrameworkCore
{
    public static class BambooDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BambooDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BambooDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
