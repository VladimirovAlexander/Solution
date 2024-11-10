namespace Solution.Dto
{
    public class DepartmentStatsDto
    {
        public string DepartmentName { get; set; } 
        public int? MinSalary { get; set; } 
        public int? MaxSalary { get; set; } 
        public DateOnly StartDate { get; set; } 
        public DateOnly EndDate { get; set; } 
        public int EmployeeCount { get; set; } 
    }
}
