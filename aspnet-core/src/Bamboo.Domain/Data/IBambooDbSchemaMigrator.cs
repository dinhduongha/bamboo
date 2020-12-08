using System.Threading.Tasks;

namespace Bamboo.Data
{
    public interface IBambooDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
