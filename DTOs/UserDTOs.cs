using System.ComponentModel.DataAnnotations;

namespace ASPNET_WebAPI.DTOs
{
    public class UserDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
    public class CreateUserDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
