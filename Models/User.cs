using System.ComponentModel.DataAnnotations;

namespace ASPNET_WebAPI.Models
{
    // 1 - Create a Model => root / Models / User.cs
    public class User
    {
        public int Id { get; set; }
        [Required] // Data Annotations are needed to validate the field in ejecution time, useful for model validation in APIs
        public required string Name { get; set; }
        [Required]
        public required string Email { get; set; }
    }
}
