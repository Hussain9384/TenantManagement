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
        public string Name { get; set; }
        public IEnumerable<Address> AddressList { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<TenantProperty> Properties{ get; set; }
        public IEnumerable<ContactDetail> ContactDetails { get; set; }
    }
}
