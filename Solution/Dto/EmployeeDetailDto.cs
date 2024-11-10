using Solution.Models;

namespace Solution.Dto
{
    public class EmployeeDetailDto
    {
       

        public string? FirstName { get; set; }

        public string LastName { get; set; } = null!;

        public string DepartmentName { get; set; } = null!;

        public string JobTitle { get; set; } = null!;

        public string? StreetAddress { get; set; }

        public string? CountryName { get; set; }
        
        public string? RegionName { get; set; }
    }
}
