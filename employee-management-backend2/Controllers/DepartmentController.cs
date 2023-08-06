using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_management_backend2.DTOs.department;
using employee_management_backend2.Models;
using employee_management_backend2.Services;
using Microsoft.AspNetCore.Mvc;


namespace employee_management_backend2.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet()]
    public async Task<ActionResult<ServiceResponse<List<DepartmentResDTO>>>> GetAll()
    {
        var projects = await _departmentService.GetAllDepartments();
        return Ok(projects.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<DepartmentResDTO>>>> GetSingle(int id)
    {
        return Ok(await _departmentService.GetById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<DepartmentResDTO>>>> AddDepartment(DepartmentReqDTO newDepartment)
    {
        return Ok(await _departmentService.Create(newDepartment));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<DepartmentResDTO>>> UpdateDepartment(int id, DepartmentReqDTO updatedDepartment)
    {
        var response = await _departmentService.Update(id, updatedDepartment);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<DepartmentResDTO>>> Delete(int id)
    {
        var response = await _departmentService.Delete(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

}



