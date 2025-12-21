
using Entities;

namespace Data.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee?> GetEmployeeByIdAsync(int i);
        public Task AddEmployeeAsync(Employee e);
        public Task InActiveEmployeeByIdAsync(int i);
        public Task ActiveEmployeeByIdAsync(int i);
        public Task UpdateEmployeeAsync(Employee e);

    }
}
