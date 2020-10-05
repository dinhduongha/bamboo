using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Bamboo.Authorization.Roles;
using Bamboo.Authorization.Users;
using Bamboo.MultiTenancy;

namespace Bamboo.EntityFrameworkCore
{
    public class BambooDbContext : AbpZeroDbContext<Tenant, Role, User, BambooDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BambooDbContext(DbContextOptions<BambooDbContext> options)
            : base(options)
        {
        }
    }
}
