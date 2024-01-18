using System.ComponentModel.DataAnnotations;

namespace Medical.Application.Dtos.User
{
    public class UserForCreationDto
    {
        
        public string? FirstName { get; init; }
        public string? LastName { get; init; }

        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(10, ErrorMessage = "The password must have 8 digit")]
        public string? Password { get; init; }
        public string? PhoneNumber { get; init; }
        public ICollection<string>? Roles { get; init; }
    }
}
