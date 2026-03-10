using EventFlow.Business.Dtos.UserDtos;

namespace EventFlow.Business.Services.Abstractions;

public interface IAuthService
{
    Task<ResultDto> RegisterAsync(RegisterDto dto);
    Task<ResultDto<AccessTokenDto>> LoginAsync(LoginDto dto);
    Task<ResultDto<AccessTokenDto>> RefreshTokenAsync(string token);
}
