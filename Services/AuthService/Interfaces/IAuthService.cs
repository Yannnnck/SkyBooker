using AuthService.DTOs;
using AuthService.Common;

namespace AuthService.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest request);
        Task<ApiResponse<string>> RegisterAsync(RegisterRequest request);
    }
}