using System.ComponentModel.DataAnnotations;

namespace Medical.Application.Dtos.User
{
    public class UserDto
    {
        public string? FirstName { get; init; }

        public string? LastName { get; init; }

        public string? Email { get; set; }

        public string? UserName { get; init; }

        public string? PhoneNumber { get; init; }
    }
}
