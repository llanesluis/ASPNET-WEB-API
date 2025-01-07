using ASPNET_WebAPI.DTOs;
using ASPNET_WebAPI.Models;
using ASPNET_WebAPI.Repositories.UserRepository;

namespace ASPNET_WebAPI.Services.UserService
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly CancellationToken _cancellationToken;

        public UserService(IUserRepository userRepository, CancellationToken cancellationToken)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync(_cancellationToken);
            
            // Mapping from Entity to DTO
            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                Email = u.Email,
                Name = u.Name
            });
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id, _cancellationToken);

            if (user == null)
                return null;

            // Mapping from Entity to DTO
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };
        }

        public async Task<UserDTO> CreateAsync(CreateUserDTO user)
        {
            // Mapping from DTO to Entity because the repository expects an Entity
            User userToCreate = new User
            {
                Name = user.Name,
                Email = user.Email
            };

            await _userRepository.CreateAsync(userToCreate, _cancellationToken);

            // Mapping back from Entity to DTO
            return new UserDTO
            {
                Id = userToCreate.Id,
                Email = userToCreate.Email,
                Name = userToCreate.Name
            };
        }

        public async Task UpdateAsync(int id, UpdateUserDTO user)
        {
            var existingUser = await _userRepository.GetByIdAsync(id, _cancellationToken);

            // To be defined, still don't know how to handle this
            if (existingUser is null)
                throw new Exception("User not found");

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            await _userRepository.UpdateAsync(existingUser, _cancellationToken);
        }

        public async Task DeleteAsync(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id, _cancellationToken);

            // To be defined, still don't know how to handle this
            if (existingUser is null)
                throw new Exception("User not found");

            await _userRepository.DeleteAsync(existingUser, _cancellationToken);
        }
    }
}
