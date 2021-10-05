using System.Threading.Tasks;
using TenantManagement.Processor.Models;

namespace TenantManagement.Processor.Processor
{
    public interface IAuthProcessor
    {
        Task<TokenInfo> ValidateCredentials(LoginRequest loginRequest);
    }
}