using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity=TenantManagement.InfraStructure.Entities;
using TenantManagement.Processor.DbContracts;
using Domain=TenantManagement.Processor.Models;
using TenantManagement.InfraStructure.Database;
using AppBaseEntity.BaseRepository;

namespace TenantManagement.InfraStructure.Repository
{   
    public class TenantCommandRepository : BaseCommandRepository<TenantDatabase>, ITenantCommandRepository
    {
        private readonly TenantDatabase _tenantDatabase;

        public TenantCommandRepository(IMapper mapper,TenantDatabase  tenantDatabase):base(mapper, tenantDatabase)
        {
            _tenantDatabase = tenantDatabase;
        }

        public async Task<Domain.Tenant> CreateTenant(Domain.Tenant tenant)
        {
           var domainModel = await Create<Domain.Tenant, Entities.Tenant>(tenant);
            return domainModel;
        }

        public Domain.Tenant DeleteTenant(Domain.Tenant tenant)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Tenant> UpdateTenant(Domain.Tenant tenant)
        {
            var domainModel = await Update<Domain.Tenant, Entities.Tenant>(tenant);
            return domainModel;
        }

    }
}
