using System.Security.Claims;

namespace EventFlow.Business.Services.Abstractions;

public interface IJWTService
{
    AccessTokenDto CreateAccessToken(List<Claim> claims);
}
