using Solution.Models;

namespace Solution.Dto
{
    public class TaskDto
    {
        public List<Employee> Task1 { get; set; }
        public List<EmployeeDataDto> Task2 { get; set; }

        public LocationDto Task3 { get; set; }  
        public List<EmployeeRequisiteDto> Task4 { get; set; }

        public List<EmployeeEuropeDto> Task5 { get; set; }

        public List<EmployeeDetailDto> Task6 { get; set; }

        public List<RegionsDto> Task7 { get; set; }

        public List<DepartmentStatsDto> Task8 { get; set; }

        public List<EmployeeNumberDto> Task9 { get; set; }

        public List<EmployeeDepartmentDadDto> Task10 { get; set; }
    }
}
