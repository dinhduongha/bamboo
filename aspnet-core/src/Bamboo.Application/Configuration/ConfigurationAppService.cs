using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Bamboo.Configuration.Dto;

namespace Bamboo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BambooAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
