using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantManagement.Processor.Models
{
    public class Summary
    {
        public int TenantsCount { get; set; }
        public int ActiveTenantsCount { get; set; }
        public int InActiveTenantsCount { get; set; }
    }
}
