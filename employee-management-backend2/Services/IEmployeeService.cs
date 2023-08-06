using System;
using employee_management_backend2.DTOs.employee;
using employee_management_backend2.Models;

namespace employee_management_backend2.Services;

public interface IEmployeeService
{
    Task<ServiceResponse<List<EmployeeResDTO>>> GetAllEmployees();
    Task<ServiceResponse<EmployeeResDTO>> GetById(int id);
    Task<ServiceResponse<EmployeeResDTO>> Create(EmployeeReqDTO newEmployee);
    Task<ServiceResponse<EmployeeResDTO>> Update(int id, EmployeeReqDTO updatedEmployee);
    Task<ServiceResponse<List<EmployeeResDTO>>> Delete(int id);
    Task<ServiceResponse<List<EmployeeResDTO>>> GetEmployeesByDepartment(int departmentId);
    Task<ServiceResponse<List<EmployeeResDTO>>> GetEmployeesByJobTitle(int jobTitleId);
}


