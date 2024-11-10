using System;
using System.Collections.Generic;

namespace Solution.Models;

public partial class Job
{
    public long JobId { get; set; }

    public string JobTitle { get; set; } = null!;

    public int? MinSalary { get; set; }

    public int? MaxSalary { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<JobHistory> JobHistories { get; set; } = new List<JobHistory>();
}
