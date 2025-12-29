using Data.Interfaces;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        readonly AppDbContext _context;
        public RoleRepository(AppDbContext context) { _context = context; }

        public async Task<int> CreateAsync( RoleEntity role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role.Id;
        }
        public async Task DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id)
                ?? throw new KeyNotFoundException("role not found");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
        public async Task<RoleEntity?> GetByIdAsync(int id)
        {
            return await _context.Roles.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<RoleEntity>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task UpdateAsync(RoleEntity role)
        {
            await _context.SaveChangesAsync();
        }
        public async Task AddEmployeeAsync(int roleId, int employeeId)
        {
            var role = await _context.Roles.Include(d => d.Employees)
                  .FirstOrDefaultAsync(d => d.Id == roleId)
                  ?? throw new KeyNotFoundException("role not found");

            var employee = await _context.Employees.FindAsync(employeeId)
                ?? throw new KeyNotFoundException("Employee not found");

            role.Employees.Add(employee);

            await _context.SaveChangesAsync();

        }
        public async Task RemoveEmployeeAsync(int roleId, int employeeId)
        {
            var role = await _context.Roles.Include(d => d.Employees)
                 .FirstOrDefaultAsync(d => d.Id == roleId)
                 ?? throw new KeyNotFoundException("role not found");

            var employee = await _context.Employees.FindAsync(employeeId)
                ?? throw new KeyNotFoundException("Employee not found");

            role.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }

    }
}

