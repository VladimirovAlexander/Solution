using System;
using System.Collections.Generic;

namespace Solution.Models;

public partial class Region
{
    public long RegionId { get; set; }

    public string? RegionName { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
