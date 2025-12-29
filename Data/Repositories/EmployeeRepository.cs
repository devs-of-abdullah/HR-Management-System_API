using Data.Interfaces;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            return await _context.Employees.Where(e => e.IsActive).Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HireDate = e.HireDate,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                RoleId = e.RoleId,


            }).AsNoTracking().ToListAsync();
           
        }
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            return await _context.Employees.Where(e => e.Id == id).Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HireDate = e.HireDate,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                RoleId = e.RoleId,

            }).FirstOrDefaultAsync();
      
        }

        public async Task<EmployeeEntity?> GetEntityByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id ==  id);
        }

        public async Task AddAsync(EmployeeEntity employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
           
        }
        public async Task UpdateAsync(EmployeeEntity employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task SetActiveAsync(int id, bool isActive)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return;
           

            employee.IsActive = isActive;
            await _context.SaveChangesAsync();
        }
     
        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null) return;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

    }
}
