using Data.Interfaces;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context) { _context = context; }

        public async Task CreateDepartment(CreateDepartmentDto Dto)
        {
            var department = new DepartmentEntity()
            {
                Name = Dto.Name,
                Description = Dto.Description,

            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDepartment(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (department== null) return;

            _context.Departments.Remove(department);

            await _context.SaveChangesAsync();
        }
        public async Task<DepartmentDto?> GetDepartment(int id)
        {
            var department = await _context.Roles.FirstOrDefaultAsync(d => d.Id == id);
            if (department == null) return null;

            var departmentDto = new DepartmentDto()
            {
                Id = id,
                Name = department.Name,
                Description = department.Description,

            };
            return departmentDto;
        }

        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments.ToListAsync();

            var departmentDto = departments.Select(d => new DepartmentDto
            {
                
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,


            }).ToList();

            return departmentDto;
        }
        public async Task UpdateDepartment(int Id, UpdateDepartmentDto dto)
        {

            var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == Id);
            if (department == null) return;

            department.Name = dto.Name;
            department.Description = dto.Description;



            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

        }
        public async Task AddEmployeeToDepartment(int departmentId, int employeeId)
        {
            var  department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentId);
            if (department == null) return;

            var  employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null) return;

            department.Employees.Add(employee);

            await _context.SaveChangesAsync();

        }
        public async Task RemoveEmployeeFromDepartment(int departmentId, int employeeId)
        {
            var  department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentId);
            if (department == null) return;

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            if (employee == null) return;

            department.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }

    }
}
