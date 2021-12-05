using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenantManagement.Api.Dto
{
    public class Summary
    {
        public int TenantsCount { get; set; }
        public int ActiveTenantsCount { get; set; }
        public int InActiveTenantsCount { get; set; }
    }
}
