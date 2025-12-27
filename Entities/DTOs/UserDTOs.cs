
namespace Entities.DTOs
{
   
    
        public class RegisterUserDto
        {
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;

        }
        public class LoginUserDto
        {
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
        }
        public class UserAuthResponseDto
        {
            public bool Success { get; set; } = false;
            public string? Message { get; set; }
            public string? Token { get; set; }
        }
        public class UserDto
        {
            public int Id { get; set; }
            public string Email { get; set; } = null!;
            public string? Password { get; set; } = null!;
        }
     
}
