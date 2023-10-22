using EmployeeMS.Data.Entities;
using EmployeeMS.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using EmployeeMS.Models;

namespace EmployeeMS.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(int pageNumber = 1, int pageSize = 10)
        {
            var totalItems = await _context.Employee
                .Where(x => !x.IsDeleted)
                .CountAsync();

            var employees = await _context.Employee
                .Include(e => e.CreatedBy)
                .Include(e => e.Department)
                .Where(x => !x.IsDeleted)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<Employee>(employees, pageNumber, pageSize, totalItems);
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Employee
                .Include(e => e.CreatedBy)
                .Include(e => e.Department)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Guid id, Employee employee)
        {
            var existingEmployee = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.Phone = employee.Phone;
                existingEmployee.DepartmentId = employee.DepartmentId;
                existingEmployee.IsStillWorking = employee.IsStillWorking;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                employee.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
