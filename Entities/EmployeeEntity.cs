
namespace Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Role { get; set; } = null;       
        public string? Department { get; set; } = null; 
        public string? PhoneNumber { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
