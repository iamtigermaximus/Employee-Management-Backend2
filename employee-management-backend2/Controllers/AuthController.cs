using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_management_backend2.DTOs.auth;
using employee_management_backend2.Models;
using employee_management_backend2.Services;
using Microsoft.AspNetCore.Mvc;


namespace employee_management_backend2.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class AuthController : ControllerBase
{
    public static AuthResDTO user = new AuthResDTO();
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<AuthResDTO>>> Login(AuthReqDTO request)
    {
        return Ok(await _authService.Login(request));
    }
}

