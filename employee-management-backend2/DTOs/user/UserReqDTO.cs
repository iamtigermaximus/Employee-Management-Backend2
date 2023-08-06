using System;
namespace employee_management_backend2.DTOs.user;

public class UserReqDTO
{
    public string Id { get; set; }
    public string UserName { get; set; } = "";
    public string Email { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Password { get; set; } = "";
}

