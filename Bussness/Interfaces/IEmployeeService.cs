using Entities;
using Entities.DTOs;
namespace Business.Interfaces
{
    public interface IEmployeeService
    {
        
            Task<List<ReadEmployeeDto>> GetAllEmployeesAsync();
            Task<ReadEmployeeDto?> GetEmployeeByIdAsync(int i);
            Task AddEmployeeAsync(CreateEmployeeDto d);
            Task InActiveEmployeeByIdAsync(int i);
            Task ActiveEmployeeByIdAsync(int i);
            Task UpdateEmployeeAsync(UpdateEmployeeDto d);

        
    }
}
