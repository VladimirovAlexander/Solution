using System;
using System.Collections.Generic;

namespace Solution.Models;

public partial class Employee
{
    public long EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly HireDate { get; set; }

    public long JobId { get; set; }

    public int? Salary { get; set; }

    public int? CommissionPct { get; set; }

    public long? ManagerId { get; set; }

    public long? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Job Job { get; set; } = null!;

    public virtual Employee? Manager { get; set; }
}
