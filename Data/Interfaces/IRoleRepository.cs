

using Entities;
using Entities.DTOs;

namespace Data.Interfaces
{
    public interface IRoleRepository
    {
        Task CreateRole(CreateRoleDto role);
        Task DeleteRole(int id);
        Task UpdateRole(int Id, UpdateRoleDto role);
        Task<RoleDto?> GetRole(int id);
        Task<List<RoleDto>> GetAllRolesAsync();
        Task AddEmployeeToRole(int roleId, int employeeID);
        Task RemoveEmployeeFromRole(int roleId, int employeeID);
    }
}

