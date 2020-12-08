using Volo.Abp.Settings;

namespace Bamboo.Settings
{
    public class BambooSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BambooSettings.MySetting1));
        }
    }
}
