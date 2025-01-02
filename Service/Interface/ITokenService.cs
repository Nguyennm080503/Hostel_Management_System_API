﻿using System.Security.Claims;
using Dtos.Account;

namespace Service.Interface
{
    public interface ITokenService
    {
        string CreateToken(LoginAccountDto loginAccountDto);
        string CreateToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
