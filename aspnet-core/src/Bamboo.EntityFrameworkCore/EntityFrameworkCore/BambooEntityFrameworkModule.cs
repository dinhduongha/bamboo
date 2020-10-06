using Abp.EntityFrameworkCore.Configuration;
using Abp.IdentityServer4vNext;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Bamboo.EntityFrameworkCore.Seed;

namespace Bamboo.EntityFrameworkCore
{
    [DependsOn(
        typeof(BambooCoreModule), 
        typeof(AbpZeroCoreIdentityServervNextEntityFrameworkCoreModule))]
    public class BambooEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<BambooDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        BambooDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        BambooDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
