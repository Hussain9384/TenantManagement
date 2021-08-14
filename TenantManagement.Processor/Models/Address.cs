namespace TenantManagement.Processor.Models
{
    public class Address : BaseModel
    {
        public string PinCode { get; set; }
        public string StreetName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
    }
}