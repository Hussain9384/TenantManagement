namespace TenantManagement.Api.Dto
{ 
    public class User:BaseModel
    {
        public string UserName { get; set; }
        public string Password{ get; set; }
    }
}