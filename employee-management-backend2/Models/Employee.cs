using System;
namespace employee_management_backend2.Models;

public class Employee : BaseModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public int JobTitleId { get; set; }
    public JobTitle? JobTitle { get; set; }
}

