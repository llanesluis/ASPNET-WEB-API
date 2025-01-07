using ASPNET_WebAPI.DTOs;

namespace ASPNET_WebAPI.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(int id);
        Task<UserDTO> CreateAsync(CreateUserDTO user);
        Task UpdateAsync(int id, UpdateUserDTO user);
        Task DeleteAsync(int id);
    }
}
