using System;
using employee_management_backend2.DTOs.jobtitle;
using employee_management_backend2.Models;

namespace employee_management_backend2.Services;

public interface IJobTitleService
{
    Task<ServiceResponse<List<JobTitleResDTO>>> GetAll();
    Task<ServiceResponse<JobTitleResDTO>> GetById(int id);
    Task<ServiceResponse<List<JobTitleResDTO>>> Create(JobTitleReqDTO newJobTitle);
    Task<ServiceResponse<JobTitleResDTO>> Update(int id, JobTitleReqDTO updatedJobTitle);
    Task<ServiceResponse<List<JobTitleResDTO>>> Delete(int id);
}


