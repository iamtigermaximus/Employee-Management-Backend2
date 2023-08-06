using System;
namespace employee_management_backend2.DTOs.auth;

public class AuthReqDTO
{
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}

