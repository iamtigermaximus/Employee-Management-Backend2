using System;
using AutoMapper;
using employee_management_backend2.Data;
using employee_management_backend2.DTOs.jobtitle;
using employee_management_backend2.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_management_backend2.Services.Impl;

public class JobTitleService : IJobTitleService
{

    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public JobTitleService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<ServiceResponse<List<JobTitleResDTO>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<JobTitleResDTO>>();
        var dbJobTitles = await _context.JobTitles
           .ToListAsync();

        serviceResponse.Data = dbJobTitles.Select(d => _mapper.Map<JobTitleResDTO>(d)).ToList();
        return serviceResponse;
    }


    public async Task<ServiceResponse<JobTitleResDTO>> GetById(int id)
    {
        var serviceResponse = new ServiceResponse<JobTitleResDTO>();
        try
        {
            var jobTitle = await _context.JobTitles
                .FirstOrDefaultAsync(d => d.Id == id);

            serviceResponse.Data = _mapper.Map<JobTitleResDTO>(jobTitle);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    public async Task<ServiceResponse<List<JobTitleResDTO>>> Create(JobTitleReqDTO newJobTitle)
    {
        var serviceResponse = new ServiceResponse<List<JobTitleResDTO>>();
        try
        {
            var jobTitle = _mapper.Map<JobTitle>(newJobTitle);

            _context.JobTitles.Add(jobTitle);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.JobTitles
                    .Select(e => _mapper.Map<JobTitleResDTO>(e))
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<JobTitleResDTO>> Update(int id, JobTitleReqDTO updatedJobTitle)
    {
        var serviceResponse = new ServiceResponse<JobTitleResDTO>();

        try
        {
            var jobTitle = await _context.JobTitles.FirstOrDefaultAsync(e => e.Id == id);

            if (jobTitle is null)

                throw new Exception($"Job Title with Id '{id}' not found.");
            jobTitle.Title = updatedJobTitle.Title;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<JobTitleResDTO>(jobTitle);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<JobTitleResDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<JobTitleResDTO>>();

        try
        {
            var jobTitle = await _context.JobTitles.FirstOrDefaultAsync(j => j.Id == id);
            if (jobTitle is null)
                throw new Exception($"Job Title with Id '{id}' not found.");

            _context.JobTitles.Remove(jobTitle);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.JobTitles.Select(e => _mapper.Map<JobTitleResDTO>(e)).ToListAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

}


