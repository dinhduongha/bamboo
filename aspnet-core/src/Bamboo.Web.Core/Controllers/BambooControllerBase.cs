using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Bamboo.Controllers
{
    public abstract class BambooControllerBase: AbpController
    {
        protected BambooControllerBase()
        {
            LocalizationSourceName = BambooConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
