using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;

using Bamboo.Authorization.Roles;
using Bamboo.Authorization.Users;
using Bamboo.MultiTenancy;
using Abp.IdentityServer4vNext;
using Bamboo.Base.Core;

namespace Bamboo.EntityFrameworkCore
{
    public class BambooDbContext : AbpZeroDbContext<Tenant, Role, User, BambooDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<CountryGroup> CountryGroup { get; set; }
        public DbSet<CountryState> CountryState { get; set; }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyRate> CurrencyRate { get; set; }

        public DbSet<PartnerTitle> PartnerTitle { get; set; }
        public DbSet<PartnerCategory> PartnerCatagory { get; set; }
        public DbSet<Partner> Partner { get; set; }


        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public BambooDbContext(DbContextOptions<BambooDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
#if HAS_DB_POSTGRESQL
            modelBuilder.InitExtension();
#endif
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigurePersistedGrantEntity();

#if HAS_DB_POSTGRESQL
            modelBuilder.UseSerialColumns();
            modelBuilder.StringSize();
            modelBuilder.PostgreSQLDataType();
            modelBuilder.SnakeCase();
#endif
        }
    }
}
