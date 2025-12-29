using Data.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context) { _context = context; }

        public async Task<int> CreateAsync(DepartmentEntity department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department.Id;
        }
        public async Task DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id) 
                ?? throw new KeyNotFoundException("department not found");

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
        public async Task<DepartmentEntity?> GetByIdAsync(int id)
        {
            return await _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DepartmentEntity>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task UpdateAsync(DepartmentEntity department)
        {
            await _context.SaveChangesAsync();
        }
        public async Task AddEmployeeAsync(int departmentId, int employeeId)
        {
            var department = await _context.Departments.Include(d => d.Employees)
                  .FirstOrDefaultAsync(d => d.Id == departmentId)
                  ?? throw new KeyNotFoundException("Department not found");

            var employee = await _context.Employees.FindAsync(employeeId)
                ?? throw new KeyNotFoundException("Employee not found");

            department.Employees.Add(employee);

            await _context.SaveChangesAsync();

        }
        public async Task RemoveEmployeeAsync(int departmentId, int employeeId)
        {
            var department = await _context.Departments.Include(d => d.Employees)
                      .FirstOrDefaultAsync(d => d.Id == departmentId)
                      ?? throw new KeyNotFoundException("Department not found");

            var employee = await _context.Employees.FindAsync(employeeId)
                ?? throw new KeyNotFoundException("Employee not found");

            department.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }

    }
}
