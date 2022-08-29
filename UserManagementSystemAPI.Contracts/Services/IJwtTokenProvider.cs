using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.Contracts.Services
{
    public interface IJwtTokenProvider
    {
        JwtSecurityToken CreateRefreshToken(List<Claim> authClaims);
        JwtSecurityToken CreateAccessToken(List<Claim> authClaims);
        TokenValidationParameters GetValidationParameters();
    }
}
