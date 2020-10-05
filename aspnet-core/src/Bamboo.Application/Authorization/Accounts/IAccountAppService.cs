using System.Threading.Tasks;
using Abp.Application.Services;
using Bamboo.Authorization.Accounts.Dto;

namespace Bamboo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
