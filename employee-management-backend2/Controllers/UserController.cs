using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using employee_management_backend2.DTOs.user;
using employee_management_backend2.Models;
using employee_management_backend2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace employee_management_backend2.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<UserResDTO>>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<UserResDTO>>> GetUserById(string id)
    {
        var user = await _userService.GetUserById(id);
        if (!user.Success)
        {
            return NotFound(user);
        }

        return Ok(user.Data);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<UserResDTO>>> CreateUser(UserReqDTO newUser)
    {
        var user = await _userService.CreateUser(newUser);
        if (!user.Success)
        {
            return BadRequest(user);
        }

        return Ok(user.Data);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<UserResDTO>>> UpdateUser(string id, UserReqDTO updatedUser)
    {
        var user = await _userService.UpdateUser(updatedUser);
        if (!user.Success)
        {
            return NotFound(user);
        }

        return Ok(user.Data);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<List<UserResDTO>>>> DeleteUser(string id)
    {
        var user = await _userService.DeleteUser(id);
        if (!user.Success)
        {
            return NotFound(user);
        }

        return Ok(user.Data);
    }
}


