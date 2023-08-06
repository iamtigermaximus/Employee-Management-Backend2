using System;
namespace employee_management_backend2.DTOs.auth;

public class AuthResDTO
{
    public string Id { get; set; }
    public string Token { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

}

