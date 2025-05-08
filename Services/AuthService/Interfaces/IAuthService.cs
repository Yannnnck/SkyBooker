using AuthService.DTOs;
using AuthService.Models;

namespace AuthService.Interfaces
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(LoginRequest request);
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<bool> UpdateUserAsync(int id, UpdateUserRequest request);
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(int id);
    }
}
