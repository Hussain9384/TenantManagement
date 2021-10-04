using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TenantManagement.Api.Dto
{
    public class Tenant : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public IEnumerable<TenantProperty> Properties { get; set; }
    }
}
