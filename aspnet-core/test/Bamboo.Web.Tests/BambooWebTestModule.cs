using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Bamboo.EntityFrameworkCore;
using Bamboo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Bamboo.Web.Tests
{
    [DependsOn(
        typeof(BambooWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BambooWebTestModule : AbpModule
    {
        public BambooWebTestModule(BambooEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BambooWebMvcModule).Assembly);
        }
    }
}