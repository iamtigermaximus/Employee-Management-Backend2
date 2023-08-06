using System;
namespace employee_management_backend2.Models;

public class Department : BaseModel
{
    public string? Name { get; set; }
    public List<Employee>? Employees { get; set; }
}

