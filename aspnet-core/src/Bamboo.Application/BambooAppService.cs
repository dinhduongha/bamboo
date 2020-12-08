using System;
using System.Collections.Generic;
using System.Text;
using Bamboo.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo
{
    /* Inherit your application services from this class.
     */
    public abstract class BambooAppService : ApplicationService
    {
        protected BambooAppService()
        {
            LocalizationResource = typeof(BambooResource);
        }
    }
}
