using EmployeeMS.Data.Entities;

namespace EmployeeMS.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(Guid id);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Guid id, Employee employee);
        Task DeleteEmployeeAsync(Guid id);
    }
}
