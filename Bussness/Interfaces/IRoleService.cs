using Entities.DTOs;

namespace Business.Interfaces
{
    public interface IRoleService
    {

        Task<int> CreateAsync(CreateRoleDto role);
        Task DeleteAsync(int id);
        Task UpdateAsync(int Id, UpdateRoleDto dto);
        Task<RoleDto?> GetByIdAsync(int id);
        Task<List<RoleDto>> GetAllAsync();
        Task AddEmployeeAsync(int roleId, int employeeID);
        Task RemoveEmployeeAsync(int roleId, int employeeID);

    }
}
