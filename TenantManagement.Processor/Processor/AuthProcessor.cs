using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TenantManagement.Processor.DbContracts;
using TenantManagement.Processor.Models;

namespace TenantManagement.Processor.Processor
{
    public class AuthProcessor : IAuthProcessor
    {
        public AuthProcessor(ITenantQueryRepository tenantQueryRepository)
        {
            _tenantQueryRepository = tenantQueryRepository;
        }

        public ITenantQueryRepository _tenantQueryRepository { get; }

        public async Task<TokenInfo> ValidateCredentials(LoginRequest loginRequest)
        {
            var tenant =await _tenantQueryRepository.GetTenantByCodeAndPass(loginRequest.TenantCode, loginRequest.TenantPassword);
           
            if (tenant !=null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(JwtRegisteredClaimNames.Aud, "Products"));
                var tokenDescription = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddMinutes(10)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken token = tokenHandler.CreateToken(tokenDescription);
                var tokenString=tokenHandler.WriteToken(token);
                return new TokenInfo { Token = tokenString };
            }
            else
            {
                throw new NotImplementedException();
            }

        }
    }
}
