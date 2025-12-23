

namespace Entities.DTOs
{
    public class CreateRoleDto
    {
        public string RoleName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
    public class UpdateRoleDto
    {
        public string RoleName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }

    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<RoleDto> Employees { get; set; } = null!;

    }
}