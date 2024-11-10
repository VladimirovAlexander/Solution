using Microsoft.AspNetCore.Mvc;
using Solution.Dto;
using Solution.Models;

namespace Solution.Interface
{
    public interface IResultRepository
    {
        Task<List<Employee>> GetEmployeeAsync();

        Task<List<EmployeeDataDto>> GetDataEmployeeAsync();

        Task<LocationDto> GetCityAsync();
        Task<List<EmployeeRequisiteDto>> GetRequisiteAsync();

        Task<List<EmployeeEuropeDto>> GetEuropeEmployeeAsync();

        Task<List<EmployeeDetailDto>> GetEmployeeDetailsAsync();

        Task<List<RegionsDto>> GetRegionEmployeeAsync();

        Task<List<DepartmentStatsDto>> GetDepartmentStatsAsync();

        Task<List<EmployeeNumberDto>> GetEmployeeNumberAsync();

        Task<List<EmployeeDepartmentDadDto>> GetEmployeeDADAsync();
    }
}
