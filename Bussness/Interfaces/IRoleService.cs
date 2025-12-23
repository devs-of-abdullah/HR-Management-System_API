using Entities;
using Entities.DTOs;

namespace Business.Interfaces
{
    public interface IRoleService
    {
        Task CreateRole(CreateRoleDto role);
        Task DeleteRole(int id);
        Task UpdateRole(int Id, UpdateRoleDto dto);
        Task<RoleDto?> GetRole(int id);
        Task<List<RoleDto>> GetAllRolesAsync();
        Task AddEmployeeToRole(int roleId, int employeeID);
        Task RemoveEmployeeFromRole(int roleId, int employeeID);
    }
}
