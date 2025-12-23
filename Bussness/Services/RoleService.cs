
using Business.Interfaces;
using Data.Interfaces;
using Entities.DTOs;

namespace Business.Services
{
    public class RoleService : IRoleService
    {
        readonly IRoleRepository _repo;
        public RoleService(IRoleRepository repo) { _repo = repo; }

        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            return await _repo.GetAllRolesAsync();
        }
        public async Task<RoleDto?> GetRole(int id)
        {
            var r = await _repo.GetRole(id);
            if (r == null) return null;
            RoleDto roleDto = new RoleDto()
            {
                RoleName = r.RoleName,
                Description = r.Description,
                Id = r.Id,
            };
            return roleDto;

        }
        public async Task CreateRole(CreateRoleDto dto)
        {
           await _repo.CreateRole(dto);
   
        }
        public async Task UpdateRole(int Id, UpdateRoleDto dto)
        {
            await _repo.UpdateRole(Id, dto);
        }
        public async Task DeleteRole(int id) 
        {
            await _repo.DeleteRole(id);
        }
        public async Task AddEmployeeToRole(int roleId, int employeeId)
        {
            await _repo.AddEmployeeToRole(roleId, employeeId);
        }
        public async Task RemoveEmployeeFromRole(int roleId, int employeeId)
        {
            await _repo.RemoveEmployeeFromRole(roleId, employeeId);
        }
    }
}
