using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity=TenantManagement.InfraStructure.Entities;
using Domain=TenantManagement.Processor.Models;

namespace TenantManagement.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dto.Tenant, Domain.Tenant>();
            CreateMap<Domain.Tenant, Dto.Tenant>();
            CreateMap<Domain.Tenant, Entity.Tenant>(); 
            CreateMap<Entity.Tenant, Domain.Tenant>();

            CreateMap<Dto.Address, Domain.Address>();
            CreateMap<Domain.Address, Dto.Address>();
            CreateMap<Domain.Address, Entity.Address>();
            CreateMap<Entity.Address, Domain.Address>();

            CreateMap<Dto.User, Domain.User>();
            CreateMap<Domain.User, Dto.User>();
            CreateMap<Domain.User, Entity.User>();
            CreateMap<Entity.User, Domain.User>();

            CreateMap<Dto.TenantProperty, Domain.TenantProperty>();
            CreateMap<Domain.TenantProperty, Dto.TenantProperty>();
            CreateMap<Domain.TenantProperty, Entity.TenantProperty>();
            CreateMap<Entity.TenantProperty, Domain.TenantProperty>();

            CreateMap<Dto.ContactDetail, Domain.ContactDetail>();
            CreateMap<Domain.ContactDetail, Dto.ContactDetail>();
            CreateMap<Domain.ContactDetail, Entity.ContactDetail>();
            CreateMap<Entity.ContactDetail, Domain.ContactDetail>();

            CreateMap<Domain.TokenInfo,Dto.TokenInfo>();
            CreateMap<Dto.TokenInfo, Domain.TokenInfo>();
            CreateMap<Dto.LoginRequest, Domain.LoginRequest>();

        }
    }
}
