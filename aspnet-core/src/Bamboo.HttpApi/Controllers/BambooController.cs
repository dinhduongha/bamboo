using Bamboo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BambooController : AbpController
    {
        protected BambooController()
        {
            LocalizationResource = typeof(BambooResource);
        }
    }
}