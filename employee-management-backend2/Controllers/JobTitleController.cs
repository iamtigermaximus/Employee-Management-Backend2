using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_management_backend2.DTOs.jobtitle;
using employee_management_backend2.Models;
using employee_management_backend2.Services;
using Microsoft.AspNetCore.Mvc;


namespace employee_management_backend2.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class JobTitleController : ControllerBase
{
    private readonly IJobTitleService _jobTitleService;

    public JobTitleController(IJobTitleService jobTitleService)
    {
        _jobTitleService = jobTitleService;
    }

    [HttpGet()]
    public async Task<ActionResult<ServiceResponse<List<JobTitleResDTO>>>> GetAll()
    {
        var jobTitles = await _jobTitleService.GetAll();
        return Ok(jobTitles.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<JobTitleResDTO>>>> GetSingle(int id)
    {
        return Ok(await _jobTitleService.GetById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<JobTitleResDTO>>>> AddJobTitle(JobTitleReqDTO newJobTitle)
    {
        return Ok(await _jobTitleService.Create(newJobTitle));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<JobTitleResDTO>>> UpdateJobTitle(int id, JobTitleReqDTO updatedJobTitle)
    {
        var response = await _jobTitleService.Update(id, updatedJobTitle);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<JobTitleResDTO>>> Delete(int id)
    {
        var response = await _jobTitleService.Delete(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

}



