using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using Domain=TenantManagement.Processor.Models;
using TenantManagement.Processor.Processor;
using TenantManagement.Processor.Validations;
using System.Threading.Tasks;
using AppBaseEntity.Models;

namespace TenantManagement.Api.Controllers
{
    public class TenantController : AppController
    {
        private readonly IMapper _mapper;
        private readonly ITenantProcessor _tenantProcessor;

        public ILogger<TenantController> _logger { get; }

        public TenantController(ILogger<TenantController> logger,IMapper mapper , ITenantProcessor tenantProcessor)
        {
            _logger = logger;
            _mapper = mapper;
            _tenantProcessor = tenantProcessor;
        }

        [HttpPost("CreateTenant")]
        public async Task<IActionResult> CreateTenant(Dto.Tenant tenant)
        {
            _logger.LogInformation($"Executing {nameof(CreateTenant)} with request : {JsonConvert.SerializeObject(tenant)}");
            if (tenant == null)
            {
                _logger.LogInformation($"{nameof(CreateTenant)} failed with empty request ");
                return BadRequest();
            }
            try
            {
                var domainModel = _mapper.Map<Domain.Tenant>(tenant);
                 var res = await _tenantProcessor.CreateTenant(domainModel);                
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An Exception Occured in {nameof(CreateTenant)} :",ex);

                return BadRequest();
            }
        }

        [HttpPost("UpdateTenant")]
        public async Task<IActionResult> UpdateTenant(Dto.Tenant tenant)
        {
            string actionName = nameof(UpdateTenant);
            _logger.LogInformation($"Executing {nameof(actionName)} with request : {JsonConvert.SerializeObject(tenant)}");
            if (tenant == null)
            {
                _logger.LogInformation($"{nameof(actionName)} failed with empty request ");
                return BadRequest();
            }
            try
            {
                var domainModel = _mapper.Map<Domain.Tenant>(tenant);
                var res = await _tenantProcessor.UpdateTenant(domainModel);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An Exception Occured in {nameof(actionName)} :", ex);

                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTenant()
        {
            _logger.LogInformation($"Executing {nameof(GetAllTenant)} ");
            
            try
            {
                var res = await _tenantProcessor.GetTenants();
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An Exception Occured in {nameof(CreateTenant)} :", ex);

                return BadRequest();
            }
        }

        [HttpGet("TenantSummary")]
        public async Task<IActionResult> TenantSummary()
        {
            string actionName = nameof(TenantSummary);
            _logger.LogInformation($"Executing {actionName} ");
            try
            {
                var res = await _tenantProcessor.GetTenantSummary();
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An Exception Occured in {actionName} :", ex);
                return BadRequest();
            }
        }
    }
}
