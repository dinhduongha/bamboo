using Bamboo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bamboo.Permissions
{
    public class BambooPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BambooPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BambooPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BambooResource>(name);
        }
    }
}
