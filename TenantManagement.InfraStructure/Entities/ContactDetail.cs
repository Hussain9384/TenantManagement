namespace TenantManagement.InfraStructure.Entities
{
    public class ContactDetail:BaseEntity
    {
        public string Email { get; set; }
        public string AlternateEmail { get; set; }
        public string MobileNumber { get; set; }
        public string TelePhone { get; set; }
    }
}