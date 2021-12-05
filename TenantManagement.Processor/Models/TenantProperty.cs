using AppBaseEntity.Models;

namespace TenantManagement.Processor.Models
{
    public class TenantProperty:BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}