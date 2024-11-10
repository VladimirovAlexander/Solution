using Solution.Models;

namespace Solution.Dto
{
    public class EmployeeDepartmentDadDto
    {
        public string? FirstName { get; set; }

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public DateOnly HireDate { get; set; }

        public int? Salary { get; set; }

        public long? ManagerId { get; set; }
        
        public string DepartmentName { get; set; } 

    }
}
