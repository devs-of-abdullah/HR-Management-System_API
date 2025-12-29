

using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    
        public class CreateDepartmentDto
        {
            [Required]
            [MaxLength(100)]
            public string Name { get; set; } = null!;

            [MaxLength(500)]
            public string Description { get; set; } = string.Empty;
        }
        public class UpdateDepartmentDto 
        {
            [Required]
            [MaxLength(100)]
            public string Name { get; set; } = null!;

            [MaxLength(500)]
            public string Description { get; set; } = string.Empty;
        }
        public class DepartmentDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Description { get; set; } = string.Empty;

            public List<EmployeeDto> Employees { get; set; }  = new ();
        }
    
}
