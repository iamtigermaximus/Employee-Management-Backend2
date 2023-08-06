using System;
using employee_management_backend2.DTOs.department;
using employee_management_backend2.Models;

namespace employee_management_backend2.Services;

public interface IDepartmentService
{
    Task<ServiceResponse<List<DepartmentResDTO>>> GetAllDepartments();
    Task<ServiceResponse<DepartmentResDTO>> GetById(int id);
    Task<ServiceResponse<List<DepartmentResDTO>>> Create(DepartmentReqDTO newDepartment);
    Task<ServiceResponse<DepartmentResDTO>> Update(int id, DepartmentReqDTO updatedDepartment);
    Task<ServiceResponse<List<DepartmentResDTO>>> Delete(int id);
}

