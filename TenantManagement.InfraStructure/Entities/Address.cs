using AppBaseEntity.Models;

namespace TenantManagement.InfraStructure.Entities
{
    public class Address : BaseEntity
    {
        public string PinCode { get; set; }
        public string StreetName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
    }
}