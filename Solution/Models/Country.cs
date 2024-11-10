using System;
using System.Collections.Generic;

namespace Solution.Models;

public partial class Country
{
    public long CountryId { get; set; }

    public string? CountryName { get; set; }

    public long? RegionId { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual Region? Region { get; set; }
}
