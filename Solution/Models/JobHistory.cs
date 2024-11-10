using System;
using System.Collections.Generic;

namespace Solution.Models;

public partial class JobHistory
{
    public long EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public long JobId { get; set; }

    public long? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Job Job { get; set; } = null!;
}
