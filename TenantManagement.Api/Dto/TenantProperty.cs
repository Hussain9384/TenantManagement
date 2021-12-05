using AppBaseEntity.Models;

namespace TenantManagement.Api.Dto
{
    public class TenantProperty:BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}