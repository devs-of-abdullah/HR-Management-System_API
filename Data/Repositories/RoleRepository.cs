using Data.Interfaces;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        readonly AppDbContext _context;
        public RoleRepository(AppDbContext context) { _context = context; }

        public async Task CreateRole(CreateRoleDto roleDto)
        {
            var role = new RoleEntity()
            {               
                Name = roleDto.RoleName,
                Description = roleDto.Description,

            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRole(int id) 
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r  => r.Id == id);
            if (role == null) return;

            _context.Roles.Remove(role);
            
            await _context.SaveChangesAsync();
        }
        public async Task<RoleDto?> GetRole(int id) 
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null) return null;
            var roleDto = new RoleDto()
            {
                Id = id,
                RoleName = role.Name,
                Description = role.Description,
               
            };
            return roleDto;
        }

        public async Task<List<RoleDto>> GetAllRolesAsync()
        { 
            var roles = await _context.Roles.ToListAsync();

            var rolesDto = roles.Select(r => new RoleDto
            {
                RoleName = r.Name,
                Id = r.Id,
                Description = r.Description,
              

            }).ToList();

            return rolesDto;
        }      
        public async Task UpdateRole(int Id, UpdateRoleDto dto)
        {

            var r = await _context.Roles.FirstOrDefaultAsync(u => u.Id == Id);    
                if(r == null) return;  
            
           r.Name = dto.RoleName;
           r.Description = dto.Description;



            _context.Roles.Update(r);
            await _context.SaveChangesAsync();

        }
        public async Task AddEmployeeToRole(int roleId,int employeeId)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            if (role == null) return;
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null) return;                
            role.Employees.Add(employee);
            await _context.SaveChangesAsync();

        }
        public async Task RemoveEmployeeFromRole(int roleId, int employeeId)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            if (role == null) return;
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null) return;
            role.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

    }
}
