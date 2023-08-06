using System;
using AutoMapper;
using employee_management_backend2.Data;
using employee_management_backend2.DTOs.employee;
using employee_management_backend2.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_management_backend2.Services.Impl;


public class EmployeeService : IEmployeeService
{

    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public EmployeeService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<ServiceResponse<List<EmployeeResDTO>>> GetAllEmployees()
    {
        var serviceResponse = new ServiceResponse<List<EmployeeResDTO>>();
        var dbEmployees = await _context.Employees
           .ToListAsync();

        serviceResponse.Data = dbEmployees.Select(c => _mapper.Map<EmployeeResDTO>(c)).ToList();
        return serviceResponse;
    }


    public async Task<ServiceResponse<EmployeeResDTO>> GetById(int id)
    {
        var serviceResponse = new ServiceResponse<EmployeeResDTO>();
        try
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(s => s.Id == id);

            serviceResponse.Data = _mapper.Map<EmployeeResDTO>(employee);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    public async Task<ServiceResponse<EmployeeResDTO>> Create(EmployeeReqDTO newEmployee)
    {
        var serviceResponse = new ServiceResponse<EmployeeResDTO>();
        try
        {
            var employee = _mapper.Map<Employee>(newEmployee);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            serviceResponse.Data =
                    _mapper.Map<EmployeeResDTO>(employee);

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
    public async Task<ServiceResponse<EmployeeResDTO>> Update(int id, EmployeeReqDTO updatedEmployee)
    {
        var serviceResponse = new ServiceResponse<EmployeeResDTO>();

        try
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employee is null)
                throw new Exception($"Employee with Id '{id}' not found.");

            // Update the employee entity with the data from the DTO
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Email = updatedEmployee.Email;
            employee.PhoneNumber = updatedEmployee.PhoneNumber;
            employee.Salary = updatedEmployee.Salary;
            employee.DepartmentId = updatedEmployee.DepartmentId;
            employee.JobTitleId = updatedEmployee.JobTitleId;

            await _context.SaveChangesAsync();

            // Map the updated employee entity to the response DTO
            var employeeResDTO = _mapper.Map<EmployeeResDTO>(employee);

            serviceResponse.Data = employeeResDTO;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<EmployeeResDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<EmployeeResDTO>>();

        try
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee is null)
                throw new Exception($"Employee with Id '{id}' not found.");

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Employees.Select(e => _mapper.Map<EmployeeResDTO>(e)).ToListAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<EmployeeResDTO>>> GetEmployeesByDepartment(int departmentId)
    {
        var serviceResponse = new ServiceResponse<List<EmployeeResDTO>>();

        try
        {
            var employees = await _context.Employees
                .Where(e => e.DepartmentId == departmentId)
                .ToListAsync();

            // Map the list of Employee entities to a list of EmployeeResDTOs
            var employeeResDTOs = _mapper.Map<List<EmployeeResDTO>>(employees);

            serviceResponse.Data = employeeResDTOs;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<EmployeeResDTO>>> GetEmployeesByJobTitle(int jobTitleId)
    {
        var serviceResponse = new ServiceResponse<List<EmployeeResDTO>>();

        try
        {
            var employees = await _context.Employees
                .Where(e => e.JobTitleId == jobTitleId)
                .ToListAsync();

            // Map the list of Employee entities to a list of EmployeeResDTOs
            var employeeResDTOs = _mapper.Map<List<EmployeeResDTO>>(employees);

            serviceResponse.Data = employeeResDTOs;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}


