using System;
using System.Collections.Generic;

namespace Solution.Models;

public partial class Location
{
    public long LocationId { get; set; }

    public string? StreetAddress { get; set; }

    public string? PostalCode { get; set; }

    public string City { get; set; } = null!;

    public string? StateProvince { get; set; }

    public long? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
