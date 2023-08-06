using System;
namespace employee_management_backend2.Models;

public class JobTitle : BaseModel
{
    public string? Title { get; set; }
    public List<Employee>? Employees { get; set; }
}

