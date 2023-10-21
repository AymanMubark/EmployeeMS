using EmployeeMS.Data;
using EmployeeMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMS.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DepartmentExistsAsync(Guid id)
        {
            return await _context.Department.AnyAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Department.ToListAsync();
        }
        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(Guid id)
        {
            return await _context.Department.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateDepartmentAsync(Department department)
        {
            department.Id = Guid.NewGuid();
            _context.Department.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _context.Department.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(Guid id)
        {
            var department = await _context.Department.FindAsync(id);
            if (department != null)
            {
                _context.Department.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}
