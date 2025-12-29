
namespace Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime HireDate { get; set; } 
        public decimal Salary { get; set; }
        public int DepartmentId {  get; set; }
        public DepartmentEntity Department { get; set; } = null!;
        public int RoleId { get; set; }
        public RoleEntity Role {get;set;} = null!;
        public bool IsActive { get; set; } = true; 
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
