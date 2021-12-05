using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenantManagement.Api.Dto
{
    public class LoginRequest
    {
        public string TenantCode { get; set; }
        public string TenantPassword { get; set; }
    }
}
