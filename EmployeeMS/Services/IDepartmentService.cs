using EmployeeMS.Data.Entities;

namespace EmployeeMS.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(Guid id);
        Task CreateDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(Guid id);
        Task<bool> DepartmentExistsAsync(Guid id);
    }
}
