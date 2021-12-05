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
            _tenantDatabase.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public TenantDatabase _tenantDatabase { get; }
        public IMapper _mapper { get; }

        public async Task<Tenant> GetTenantByCodeAndPass(string tenantCode, string tenantPassword)
        {
            var tenantEntity = await _tenantDatabase.Tenants.FirstOrDefaultAsync(t => t.Code == tenantCode && t.Password == tenantPassword);
            return _mapper.Map<Tenant>(tenantEntity);
        }

        public async Task<IEnumerable<Tenant>> GetTenants()
        {
            var entities = await _tenantDatabase.Tenants.ToListAsync();
            var res=_mapper.Map<IEnumerable<Tenant>>(entities);
            return res;
        }

        public async Task<Summary> GetTenantSummary()
        {
            var tenantCounts = await _tenantDatabase.Tenants.GroupBy(t => t.IsActive).Select(g => new { IsActive = g.Key, TenantCount = g.Count() }).ToListAsync();
            var summary = new Summary()
            {
                ActiveTenantsCount = tenantCounts.Where(t => t.IsActive == true).FirstOrDefault() == null?0: tenantCounts.Where(t => t.IsActive == true).FirstOrDefault().TenantCount,
                InActiveTenantsCount = tenantCounts.Where(t => t.IsActive == false).FirstOrDefault()==null?0: tenantCounts.Where(t => t.IsActive == false).FirstOrDefault().TenantCount
            };
            summary.TenantsCount = summary.InActiveTenantsCount + summary.ActiveTenantsCount;
            return summary;
        }
    }
}
