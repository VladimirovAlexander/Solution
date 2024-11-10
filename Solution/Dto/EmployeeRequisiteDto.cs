namespace Solution.Dto
{
    public class EmployeeRequisiteDto
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

        public string JobTitle { get; set; } = null!;
    }

}
