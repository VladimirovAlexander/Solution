namespace Solution.Dto
{
    public class EmployeeHireDateDto
    {
        public string? FirstName { get; set; }

        public string LastName { get; set; } = null!;

        public DateOnly HireDate { get; set; }

       public long? ManagerId { get; set; }
    }
}
