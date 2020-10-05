using Abp.Application.Services;
using Bamboo.MultiTenancy.Dto;

namespace Bamboo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

