using TenantManagement.Processor.Models;

namespace TenantManagement.Processor.Processor
{
    public interface IAuthProcessor
    {
        TokenInfo ValidateCredentials(LoginRequest loginRequest);
    }
}