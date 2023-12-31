﻿using EmployeeMS.Data;
using EmployeeMS.Data.Entities;
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
            var totalItems = await _context.Employees
                .Where(x => !x.IsDeleted)
                .CountAsync();

            var employees = await _context.Employees
                .Include(e => e.CreatedBy)
                .Include(e => e.Department)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<Employee>(employees, pageNumber, pageSize, totalItems);
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Employees
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
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.Phone = employee.Phone;
                existingEmployee.DepartmentId = employee.DepartmentId;
                existingEmployee.IsStillWorking = employee.IsStillWorking;
                if (employee.Photo != null)
                {
                    existingEmployee.Photo = employee.Photo;
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
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
