using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Common.IServices
{
    public interface IJwtService
    {
        string GenerateAccessToken(List<Claim> claims, DateTime expireAt);
    }
}