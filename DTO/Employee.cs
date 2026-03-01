 using System.ComponentModel.DataAnnotations;

namespace DTO.Employee
{
    public record CreateEmployeeDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; init; } = null!;

        [Required, MaxLength(50)]
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;  
        [Required, MaxLength(16)] 
        public string? PhoneNumber { get; init; }

        [Required, EmailAddress, MaxLength(100)]
        public string? Department { get; init; } = null;
        public string? Role { get; init; } = null;
        public DateTime HireDate { get; init; }
        public decimal Salary { get; init; } = 0;
        }
 

    public record ReadEmployeeDto
    {
        public int Id { get; init; }
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string? PhoneNumber { get; init; }
        public DateTime HireDate { get; init; }
        public decimal Salary { get; init; }
        public bool IsActive { get; init; }
        public string? Department { get; init; }
        public string? Role { get; init; }
    }

    public record UpdateEmployeeDto
    {
        [MaxLength(50)]
        public string? FirstName { get; init; }
        [MaxLength(50)]
        public string? LastName { get; init; }
        [EmailAddress, MaxLength(100)]
        public string? Email { get; init; }
        [MaxLength(16)]
        public string? PhoneNumber { get; init; }
        public decimal? Salary { get; init; }
        public bool? IsActive { get; init; }
        public string? Department { get; init; } = null;
        public string? Role { get; init; } = null;
    }
}