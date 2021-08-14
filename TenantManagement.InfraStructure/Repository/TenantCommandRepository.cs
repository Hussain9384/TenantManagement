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

namespace TenantManagement.InfraStructure.Repository
{   
    public class TenantCommandRepository : ITenantCommandRepository
    {
        private readonly TenantDatabase _tenantDatabase;
        public IMapper _mapper { get; }

        public TenantCommandRepository(IMapper mapper,TenantDatabase  tenantDatabase)
        {
            _mapper = mapper;
            _tenantDatabase = tenantDatabase;
        }

        public async Task<Domain.Tenant> CreateTenant(Domain.Tenant tenant)
        {
            var entityModel = _mapper.Map<Entity.Tenant>(tenant);
            _tenantDatabase.Add(entityModel);
            await _tenantDatabase.SaveChangesAsync();
            var domainModel = _mapper.Map<Domain.Tenant>(entityModel);
            return domainModel;
        }

        public Domain.Tenant DeleteTenant(Domain.Tenant tenant)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Tenant> GetTenants()
        {
            throw new NotImplementedException();
        }

        public Domain.Tenant UpdateTenant(Domain.Tenant tenant)
        {
            throw new NotImplementedException();
        }
    }
}
