using System.Threading.Tasks;
using Abp.Application.Services;
using Bamboo.Sessions.Dto;

namespace Bamboo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
