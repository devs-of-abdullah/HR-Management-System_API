using Data.Interfaces;
using Entities;
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
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.Where(e => e.IsActive).ToListAsync();
        }
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
          return  await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
           
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
        }
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
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

    }
}
