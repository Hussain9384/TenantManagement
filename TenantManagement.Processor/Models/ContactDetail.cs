using AppBaseEntity.Models;

namespace TenantManagement.Processor.Models
{
    public class ContactDetail:BaseModel
    {
        public string Email { get; set; }
        public string AlternateEmail { get; set; }
        public string MobileNumber { get; set; }
        public string TelePhone { get; set; }
    }
}