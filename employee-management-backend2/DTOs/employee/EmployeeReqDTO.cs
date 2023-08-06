using System;
namespace employee_management_backend2.DTOs.employee;

public class EmployeeReqDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    public int JobTitleId { get; set; }
}

