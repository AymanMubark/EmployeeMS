using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeMS.Data;
using EmployeeMS.Data.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using EmployeeMS.Services;
using EmployeeMS.Models;

namespace EmployeeMS.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {

        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeesController(IEmployeeService employeeService,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        // GET: Employees
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var employees = await _employeeService.GetEmployeesAsync( pageNumber ,  pageSize);
            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Phone,DepartmentId,IsStillWorking,Id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.CreatedById = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _employeeService.CreateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            var departments = await _departmentService.GetAllDepartmentsAsync();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name" ,employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            var departments = await _departmentService.GetAllDepartmentsAsync();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);

            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Email,Phone,DepartmentId,IsStillWorking,Id")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(id, employee);
                return Ok();
            }

            var departments = await _departmentService.GetAllDepartmentsAsync();
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);

            return Ok(employee);
        }

        // POST: Employees/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}
