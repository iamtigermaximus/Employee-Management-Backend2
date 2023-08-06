using System;
namespace employee_management_backend2.Models;

public class BaseModel
{
    public int Id { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDateTime { get; set; } = DateTime.UtcNow;
}

