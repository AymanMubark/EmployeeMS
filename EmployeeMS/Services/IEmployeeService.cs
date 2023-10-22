using EmployeeMS.Data.Entities;
using EmployeeMS.Models;

namespace EmployeeMS.Services
{
    public interface IEmployeeService
    {
        Task<PagedList<Employee>> GetEmployeesAsync(int pageNumber = 1, int pageSize = 10);
        Task<Employee?> GetEmployeeByIdAsync(Guid id);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Guid id, Employee employee);
        Task DeleteEmployeeAsync(Guid id);
    }
}
