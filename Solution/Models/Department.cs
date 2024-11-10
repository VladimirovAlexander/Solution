using System;
using System.Collections.Generic;

namespace Solution.Models;

public partial class Department
{
    public long DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public long? ManagerId { get; set; }

    public long? LocationId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<JobHistory> JobHistories { get; set; } = new List<JobHistory>();

    public virtual Location? Location { get; set; }

    public virtual Employee? Manager { get; set; }
}
