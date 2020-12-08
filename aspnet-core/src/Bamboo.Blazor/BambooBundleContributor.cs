using Volo.Abp.Bundling;

namespace Bamboo.Blazor
{
    public class BambooBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css");
        }
    }
}
