using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bamboo.EntityFrameworkCore
{
    public static class BambooDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BambooDbContext> builder, string connectionString)
        {
#if HAS_DB_POSTGRESQL
            builder.UseNpgsql(connectionString, o => o.UseNetTopologySuite())
                   .ReplaceService<IMigrationsSqlGenerator, MyPostgresMigrationsSqlGenerator>()
                   ;
#elif HAS_DB_MSSQL
            builder.UseSqlServer(connectionString, o => o.UseNetTopologySuite());
            //"ConnectionStrings": {
            //    "Default": "User ID=postgres;Password=123qwe;Host=localhost;Port=5432;Database=PostgreSqlDemoDb;Pooling=true;"
            //}
            //
#elif HAS_DB_SQLITE
            builder.UseSqlite(connectionString, o => o.UseNetTopologySuite());
#else
            builder.UseMySql(connectionString);
#endif
        }

        public static void Configure(DbContextOptionsBuilder<BambooDbContext> builder, DbConnection connection)
        {
#if HAS_DB_POSTGRESQL
            builder.UseNpgsql(connection, o => o.UseNetTopologySuite());
#elif HAS_DB_MSSQL
            builder.UseSqlServer(connection, o => o.UseNetTopologySuite());
#elif HAS_DB_SQLITE
            builder.UseSqlite(connection, o => o.UseNetTopologySuite());
#else
            builder.UseMySql(connection);
#endif
        }
    }
}
