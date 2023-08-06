using System;
using employee_management_backend2.DTOs.auth;
using employee_management_backend2.Models;

namespace employee_management_backend2.Services;


public interface IAuthService
{
    Task<ServiceResponse<AuthResDTO>> Login(AuthReqDTO request);

}

