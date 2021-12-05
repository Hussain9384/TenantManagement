namespace TenantManagement.Processor.Models
{
    public class LoginRequest
    {
        public string TenantCode { get; set; }
        public string TenantPassword { get; set; }
    }
}