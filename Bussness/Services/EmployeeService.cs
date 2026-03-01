using Business.Interfaces;
using Data.Interfaces;
using Entities;
using DTO.Employee;

namespace Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo) { _repo = repo; }

        public async Task<List<ReadEmployeeDto>> GetAllAsync()
        {
            var employees = await _repo.GetAllAsync();
            return employees.Select(MapToDto).ToList();
        }

        public async Task<ReadEmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _repo.GetByIdAsync(id);
            if (employee == null) return null;
            return MapToDto(employee);
        }

        public async Task AddAsync(CreateEmployeeDto dto)
        {
            var employee = new EmployeeEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                HireDate = dto.HireDate,
                Salary = dto.Salary,
                Department = dto.Department,
                Role = dto.Role
            };

            await _repo.AddAsync(employee);
        }

        public async Task UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Employee not found");

            if (dto.FirstName != null) employee.FirstName = dto.FirstName;
            if (dto.LastName != null) employee.LastName = dto.LastName;
            if (dto.PhoneNumber != null) employee.PhoneNumber = dto.PhoneNumber;
            if (dto.Salary.HasValue) employee.Salary = dto.Salary.Value;
            if (dto.Department != null) employee.Department = dto.Department;
            if (dto.Role != null) employee.Role = dto.Role;

            await _repo.UpdateAsync(employee);
        }

        public async Task ActivateAsync(int id)
        {
            _ = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Employee not found");

            await _repo.SetActiveAsync(id, true);
        }

        public async Task DeactivateAsync(int id)
        {
            _ = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Employee not found");

            await _repo.SetActiveAsync(id, false);
        }

        public async Task DeleteAsync(int id)
        {
            _ = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Employee not found");

            await _repo.DeleteAsync(id);
        }

        static ReadEmployeeDto MapToDto(EmployeeEntity e) =>
            new ReadEmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HireDate = e.HireDate,
                Salary = e.Salary,
                IsActive = e.IsActive,
                Department = e.Department,
                Role = e.Role
            };
    }
}
