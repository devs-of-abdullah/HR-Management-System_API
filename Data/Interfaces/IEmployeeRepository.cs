
using Entities;
using Entities.DTOs;

namespace Data.Interfaces
{
    public interface IEmployeeRepository
    {
         Task<List<EmployeeDto>> GetAllEmployeesAsync();
         Task<EmployeeEntity?> GetEmployeeByIdAsync(int i);
         Task AddEmployeeAsync(EmployeeEntity e);
        Task InActiveEmployeeByIdAsync(int i);
         Task ActiveEmployeeByIdAsync(int i);
         Task UpdateEmployeeAsync(EmployeeEntity e);
          Task DeleteEmployeeAsync(int i);
    }
}
