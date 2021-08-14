using TenantManagement.Processor.Models;

namespace TenantManagement.Processor.Validations
{
    public  interface ITenantValidator
    {
        bool ValidateCode(Tenant  tenant);
    }
}