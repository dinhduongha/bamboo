using System.Threading.Tasks;
using Bamboo.Configuration.Dto;

namespace Bamboo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
