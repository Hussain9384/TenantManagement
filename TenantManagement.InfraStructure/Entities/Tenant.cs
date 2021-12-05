using AppBaseEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TenantManagement.InfraStructure.Entities
{
    public class Tenant : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public IEnumerable<TenantProperty> Properties{ get; set; }
        public bool IsActive { get; set; }
    }
}
