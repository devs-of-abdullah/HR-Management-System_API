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
        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
           var employee = await _context.Employees.Where(e => e.IsActive).ToListAsync();
            var dtoEmploye = employee.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName, 
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HireDate = e.HireDate,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                RoleId  = e.RoleId,

            }).ToList();

            return dtoEmploye;
           
        }
        public async Task<EmployeeEntity?> GetEmployeeByIdAsync(int id)
        {
            var e = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (e == null) return null;
            
            return e;
           
        }

        public async Task AddEmployeeAsync(EmployeeEntity e)
        {
           _context.Employees.Add(e);
            await _context.SaveChangesAsync();
           
        }
        public async Task UpdateEmployeeAsync(EmployeeEntity e)
        {
            _context.Employees.Update(e);
            await _context.SaveChangesAsync();
        }
        public async Task ActiveEmployeeByIdAsync(int id)
        {
            var e = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (e == null) return;
            if(e.IsActive) return;

            e.IsActive = true;
            await _context.SaveChangesAsync();
        }
        public async Task InActiveEmployeeByIdAsync(int id)
        {
         var e = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (e == null) return;
            if(!e.IsActive) return;
            e.IsActive = false;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            var e = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (e == null) return;
            _context.Employees.Remove(e);
            await _context.SaveChangesAsync();
        }

    }
}
