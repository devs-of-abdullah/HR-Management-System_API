

namespace Entities.DTOs
{
    
        public class CreateDepartmentDto
        {
            public string Name { get; set; } = null!;
            public string Description { get; set; } = string.Empty;
        }
        public class UpdateDepartmentDto 
        {
            public string Name { get; set; } = null!;
            public string Description { get; set; } = string.Empty;
        }
        public class DepartmentDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Description { get; set; } = string.Empty;

            public List<EmployeeEntity> Employees { get; set; }  = new List<EmployeeEntity>();
        }
    
}
