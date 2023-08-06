using System;
using AutoMapper;
using employee_management_backend2.Data;
using employee_management_backend2.DTOs.department;
using employee_management_backend2.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_management_backend2.Services.Impl;

public class DepartmentService : IDepartmentService
{

    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public DepartmentService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<ServiceResponse<List<DepartmentResDTO>>> GetAllDepartments()
    {
        var serviceResponse = new ServiceResponse<List<DepartmentResDTO>>();
        var dbDepartments = await _context.Departments
           .ToListAsync();

        serviceResponse.Data = dbDepartments.Select(d => _mapper.Map<DepartmentResDTO>(d)).ToList();
        return serviceResponse;
    }


    public async Task<ServiceResponse<DepartmentResDTO>> GetById(int id)
    {
        var serviceResponse = new ServiceResponse<DepartmentResDTO>();
        try
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == id);

            serviceResponse.Data = _mapper.Map<DepartmentResDTO>(department);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    public async Task<ServiceResponse<List<DepartmentResDTO>>> Create(DepartmentReqDTO newDepartment)
    {
        var serviceResponse = new ServiceResponse<List<DepartmentResDTO>>();
        try
        {
            var department = _mapper.Map<Department>(newDepartment);

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Departments
                    .Select(e => _mapper.Map<DepartmentResDTO>(e))
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<DepartmentResDTO>> Update(int id, DepartmentReqDTO updatedDepartment)
    {
        var serviceResponse = new ServiceResponse<DepartmentResDTO>();

        try
        {
            var department = await _context.Departments.FirstOrDefaultAsync(e => e.Id == id);

            if (department is null)

                throw new Exception($"Department with Id '{id}' not found.");
            department.Name = updatedDepartment.Name;


            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<DepartmentResDTO>(department);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<DepartmentResDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<DepartmentResDTO>>();

        try
        {
            var department = await _context.Departments.FirstOrDefaultAsync(e => e.Id == id);
            if (department is null)
                throw new Exception($"Department with Id '{id}' not found.");

            _context.Departments.Remove(department);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Departments.Select(e => _mapper.Map<DepartmentResDTO>(e)).ToListAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

}



