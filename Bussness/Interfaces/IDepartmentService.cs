

using Entities.DTOs;

namespace Business.Interfaces
{
    public interface IDepartmentService
    {
        
            Task CreateDepartment(CreateDepartmentDto role);
            Task DeleteDepartment(int id);
            Task UpdateDepartment(int Id, UpdateDepartmentDto dto);
            Task<DepartmentDto?> GetDepartment(int id);
            Task<List<DepartmentDto>> GetAllDepartmentsAsync();
            Task AddEmployeeToDepartment(int departmentId, int employeeID);
            Task RemoveEmployeeFromDepartment(int departmentId, int employeeID);
        
    }
}
