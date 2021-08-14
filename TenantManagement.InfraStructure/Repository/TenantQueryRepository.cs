using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantManagement.InfraStructure.Database;
using TenantManagement.Processor.DbContracts;
using TenantManagement.Processor.Models;

namespace TenantManagement.InfraStructure.Repository
{
    public class TenantQueryRepository : ITenantQueryRepository
    {
        public TenantQueryRepository(TenantDatabase tenantDatabase,IMapper mapper )
        {
            _tenantDatabase = tenantDatabase;
            _mapper = mapper;
        }

        public TenantDatabase _tenantDatabase { get; }
        public IMapper _mapper { get; }

        public async Task<IEnumerable<Tenant>> GetTenants()
        {
            var entities = await _tenantDatabase.Tenants.ToListAsync();
            var res=_mapper.Map<IEnumerable<Tenant>>(entities);
            return res;
        }
    }
}
