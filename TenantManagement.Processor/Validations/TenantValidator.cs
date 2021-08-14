using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantManagement.Processor.Models;

namespace TenantManagement.Processor.Validations
{
    public class TenantValidator : ITenantValidator
    {
        public bool ValidateCode(Tenant tenant)
        {
            if (String.IsNullOrWhiteSpace(tenant.Name))
            {
                return false;
            }
            return true;
        }
    }
}
