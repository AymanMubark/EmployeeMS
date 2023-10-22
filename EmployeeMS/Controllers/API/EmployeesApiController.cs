﻿using AutoMapper;
using EmployeeMS.Data.Entities;
using EmployeeMS.Models;
using EmployeeMS.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class EmployeesApiController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public readonly IMapper _mapper;

    public EmployeesApiController(IEmployeeService employeeService, IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeOutputDto>>> GetEmployees(int pageNumber = 1, int pageSize = 10)
    {
        var pagedEmployees = await _employeeService.GetEmployeesAsync(pageNumber, pageSize);

        return Ok(_mapper.Map<PagedList<EmployeeOutputDto>>(pagedEmployees));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeOutputDto>> GetEmployee(Guid id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<EmployeeOutputDto>(employee));
    }

    [HttpPost]
    public async Task<ActionResult> CreateEmployee(EmployeeInputDto employeeDTO)
    {
        if (ModelState.IsValid)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            employee.CreatedById = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _employeeService.CreateEmployeeAsync(employee);
            return Ok();
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(Guid id, [FromForm] EmployeeInputDto employeeDTO)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeDTO);
                await _employeeService.UpdateEmployeeAsync(id, employee);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok();
        }

        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        try
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
