

using System.ComponentModel.DataAnnotations;





namespace Entities.DTOs
{

    public class CreateRoleDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
    public class UpdateRoleDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;

        public List<EmployeeDto> Employees { get; set; } = new();
    }

}
