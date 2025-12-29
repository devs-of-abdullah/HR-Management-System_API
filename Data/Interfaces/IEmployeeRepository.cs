
using Entities;
using Entities.DTOs;

namespace Data.Interfaces
{
    public interface IEmployeeRepository
    {
         Task<List<EmployeeDto>> GetAllAsync();
         Task<EmployeeDto?> GetByIdAsync(int id);
        Task<EmployeeEntity?> GetEntityByIdAsync(int id);
         Task AddAsync(EmployeeEntity employee);
         Task SetActiveAsync(int id, bool isActive);
         Task UpdateAsync(EmployeeEntity employee);
         Task DeleteAsync(int i);
    }
}
