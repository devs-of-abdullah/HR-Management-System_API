using Business.Interfaces;
using Data.Interfaces;
using Entities;
using Entities.DTOs;

namespace Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo) 
        {
            _repo = repo;
        }
        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            return await _repo.GetAllAsync();        
        }
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
        public  async Task AddAsync(CreateEmployeeDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("Email is required");

            if (string.IsNullOrWhiteSpace(dto.PhoneNumber)) 
                throw new Exception("Phone Number is Required");

            var employee = new EmployeeEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                HireDate = dto.HireDate,
                Salary = dto.Salary,
                DepartmentId = dto.DepartmentId,
                RoleId = dto.RoleId,
            };
       
            await _repo.AddAsync(employee);


        }
        public async Task UpdateAsync(EmployeeDto dto)
        {

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("Email is required");
         

            if (string.IsNullOrWhiteSpace(dto.PhoneNumber))
                throw new Exception("Phone Number is Required");

            var employee = await _repo.GetEntityByIdAsync(dto.Id);

            if (employee == null) return;
         
            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.HireDate = dto.HireDate;
            employee.Salary = dto.Salary;
            employee.DepartmentId = dto.DepartmentId;
            employee.RoleId = dto.RoleId;

            await _repo.UpdateAsync(employee);
        }
        public async Task ActivateAsync(int id)
        {
           await _repo.SetActiveAsync(id,true);

        }
        public async Task DeactivateAsync(int id)
        {
           await _repo.SetActiveAsync(id,false);
        }
        public async Task DeleteAsync(int id) 
        {
            await _repo.DeleteAsync(id);
        }
    }
}
