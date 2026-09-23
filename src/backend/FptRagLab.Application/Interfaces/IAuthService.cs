using FptRagLab.Application.DTOs.Auth;

namespace FptRagLab.Application.Interfaces
{
    /// <summary>
    /// Authentication and user management service interface.
    /// Handles UC-01 Register, UC-02 Login, UC-03 Refresh Token, UC-04 Manage Profile.
    /// </summary>
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
        Task<UserInfoDto> GetProfileAsync(Guid userId);
        Task UpdateProfileAsync(Guid userId, UserInfoDto dto);
        Task RevokeTokenAsync(Guid userId);
    }
}
