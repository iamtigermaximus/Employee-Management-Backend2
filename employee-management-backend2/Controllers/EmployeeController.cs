using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_management_backend2.DTOs.employee;
using employee_management_backend2.Models;
using employee_management_backend2.Services;
using Microsoft.AspNetCore.Mvc;


namespace employee_management_backend2.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet()]
    public async Task<ActionResult<ServiceResponse<List<EmployeeResDTO>>>> GetAll()
    {
        var projects = await _employeeService.GetAllEmployees();
        return Ok(projects.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<EmployeeResDTO>>>> GetSingle(int id)
    {
        return Ok(await _employeeService.GetById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<EmployeeResDTO>>> AddEmployee(EmployeeReqDTO newEmployee)
    {
        return Ok(await _employeeService.Create(newEmployee));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<EmployeeResDTO>>> UpdateEmployee(int id, EmployeeReqDTO updatedEmployee)
    {
        var response = await _employeeService.Update(id, updatedEmployee);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<EmployeeResDTO>>> Delete(int id)
    {
        var response = await _employeeService.Delete(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }


    [HttpGet("department/{departmentId}")]
    public async Task<ActionResult<ServiceResponse<List<EmployeeResDTO>>>> GetEmployeesByDepartment(int departmentId)
    {
        var response = await _employeeService.GetEmployeesByDepartment(departmentId);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpGet("jobTitle/{jobTitleId}")]
    public async Task<ActionResult<ServiceResponse<List<EmployeeResDTO>>>> GetEmployeesByJobTitle(int jobTitleId)
    {
        var response = await _employeeService.GetEmployeesByJobTitle(jobTitleId);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }
}



