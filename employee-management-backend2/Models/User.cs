using System;
using Microsoft.AspNetCore.Identity;

namespace employee_management_backend2.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Password { get; set; } = "";
}

