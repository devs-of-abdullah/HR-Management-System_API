

using Entities.DTOs;

namespace Data.Interfaces
{
    public interface IDepartmentRepository
    {
        Task CreateDepartment(CreateDepartmentDto department);
        Task DeleteDepartment(int id);
        Task UpdateDepartment(int Id, UpdateDepartmentDto department);
        Task<DepartmentDto?> GetDepartment(int id);
        Task<List<DepartmentDto>> GetAllDepartmentsAsync();
        Task AddEmployeeToDepartment(int departmentId, int employeeID);
        Task RemoveEmployeeFromDepartment(int departmentId, int employeeID);
    }
}
