

using Business.Interfaces;
using Data.Interfaces;
using Entities.DTOs;

namespace Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        readonly IDepartmentRepository _repo;
        public DepartmentService(IDepartmentRepository repo) { _repo = repo; }

        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            return await _repo.GetAllDepartmentsAsync();
        }
        public async Task<DepartmentDto?> GetDepartment(int id)
        {
            var d = await _repo.GetDepartment(id);

            if (d == null) return null;

            var Dto = new DepartmentDto()
            {
                Name = d.Name,
                Description = d.Description,
                Id = d.Id,
            };
            return Dto;

        }
        public async Task CreateDepartment(CreateDepartmentDto dto)
        {
            await _repo.CreateDepartment(dto);

        }
        public async Task UpdateDepartment(int Id, UpdateDepartmentDto dto)
        {
            await _repo.UpdateDepartment(Id, dto);
        }
        public async Task DeleteDepartment(int id)
        {
            await _repo.DeleteDepartment(id);
        }
        public async Task AddEmployeeToDepartment(int departmentId, int employeeId)
        {
            await _repo.AddEmployeeToDepartment(departmentId, employeeId);
        }
        public async Task RemoveEmployeeFromDepartment(int departmentId, int employeeId)
        {
            await _repo.RemoveEmployeeFromDepartment(departmentId, employeeId);
        }
    }
}
