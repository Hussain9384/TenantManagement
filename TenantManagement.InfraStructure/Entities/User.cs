using AppBaseEntity.Models;

namespace TenantManagement.InfraStructure.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password{ get; set; }
    }
}