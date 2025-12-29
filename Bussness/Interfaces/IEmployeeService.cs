using Entities;
using Entities.DTOs;
namespace Business.Interfaces
{
    public interface IEmployeeService
    {
        
            Task<List<EmployeeDto>> GetAllAsync();
            Task<EmployeeDto?> GetByIdAsync(int id);
            Task AddAsync(CreateEmployeeDto employee);
            Task DeactivateAsync(int id);
            Task ActivateAsync(int id);
            Task UpdateAsync(EmployeeDto d);
            Task DeleteAsync(int id);
        
    }
}
