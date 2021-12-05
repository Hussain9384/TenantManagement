using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenantManagement.Api.Dto;
using TenantManagement.Processor.Processor;
using Domain=TenantManagement.Processor.Models;

namespace TenantManagement.Api.Controllers
{

    public class AuthController : AppController
    {
        public AuthController(ILogger<AuthController> logger, IAuthProcessor authProcessor, IMapper mapper)
        {
            _logger = logger;
            _authProcessor = authProcessor;
            _mapper = mapper;
        }

        private ILogger<AuthController> _logger { get; }
        public IAuthProcessor _authProcessor { get; }
        public IMapper _mapper { get; }

        [HttpPost]
        public async Task<IActionResult> ValidateCredentials([FromBody]LoginRequest loginRequest)
        {
            _logger.LogInformation($"Executing {nameof(ValidateCredentials)} for User : {loginRequest.TenantCode}");
            if (string.IsNullOrWhiteSpace(loginRequest.TenantCode) || string.IsNullOrWhiteSpace(loginRequest.TenantPassword))
            {
                return BadRequest();
            }
            try
            {
                var res = await _authProcessor.ValidateCredentials(_mapper.Map<Domain.LoginRequest>(loginRequest));
                return Ok(_mapper.Map<TokenInfo>(res));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
