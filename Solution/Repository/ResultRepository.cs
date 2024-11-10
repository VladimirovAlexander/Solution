using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Solution.Data;
using Solution.Dto;
using Solution.Interface;
using Solution.Models;
using System.Text.RegularExpressions;

namespace Solution.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly SolutionDbContext _context;
        public ResultRepository(SolutionDbContext context)
        {

            _context = context;

        }
        
        /// <summary>
        /// 1.	Отобразить реквизиты сотрудников, менеджеры которых устроились на работу в 2023 г., но при это сами эти работники устроились на работу до 2023 г.
        /// </summary>
        /// <returns></returns
      
        public async Task<List<EmployeeHireDateDto>> GetEmployeeAsync()
        {
            var employees = await (
                from e in _context.Employees
                where e.HireDate < new DateOnly(2023, 1, 1)
                join emp in _context.Employees on e.ManagerId equals emp.EmployeeId
                where emp.HireDate >= new DateOnly(2023, 1, 1) && emp.HireDate < new DateOnly(2024, 1, 1)
                select new EmployeeHireDateDto { 

                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    HireDate = e.HireDate,
                    ManagerId = e.ManagerId,

                }).ToListAsync();
                
            return employees;
        }

        /// <summary>
        /// 2.	Отобразить данные по сотрудникам: из какого департамента и какими текущими задачами они занимаются.
        /// Результат отобразить в трех полях: employees.First_name, jobs.Job_title, departments.Department_name
        /// </summary> 
        /// <returns></returns>

        public async Task<List<EmployeeDataDto>> GetDataEmployeeAsync()
        {
            var employee = await (
                from e in _context.Employees
                join j in _context.Jobs on e.JobId equals j.JobId
                join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                select new EmployeeDataDto
                {
                    FirstName = e.FirstName,
                    JobTitle = j.JobTitle,
                    DepartmentName = d.DepartmentName,
                }
                ).ToListAsync();

            return employee;
        }

        /// <summary>
        /// 3.	Отобразить город, в котором сотрудники в сумме зарабатывают меньше всех.
        /// </summary>
        /// <returns></returns>
        public async Task<LocationDto> GetCityAsync()
        {
            var cityWithLowestSalary = await (
                from e in _context.Employees
                join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                join l in _context.Locations on d.LocationId equals l.LocationId
                group e.Salary by l.City into cityGroup
                select new LocationDto
                {
                    City = cityGroup.Key,
                    AverageSalary = cityGroup.Sum()

                }).OrderBy(x=> x.AverageSalary).FirstOrDefaultAsync();

            return cityWithLowestSalary;
        }
        

        /// <summary>
        /// 4.	Вывести все реквизиты сотрудников менеджеры которых устроились на работу в январе месяце любого года и длина job_title этих сотрудников больше 15ти символов
        /// </summary>
        /// <returns></returns>

        public async Task<List<EmployeeRequisiteDto>> GetRequisiteAsync()
        {
            var employeeDetails = await (
                from e in _context.Employees
                join m in _context.Employees on e.ManagerId equals m.EmployeeId 
                join j in _context.Jobs on e.JobId equals j.JobId
                where m.HireDate.Month == 1 && j.JobTitle.Length > 15 
                select new EmployeeRequisiteDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    HireDate = e.HireDate,
                    JobId = e.JobId,
                    Salary = e.Salary,
                    CommissionPct = e.CommissionPct,
                    ManagerId = e.ManagerId,
                    DepartmentId = e.DepartmentId,
                    JobTitle = j.JobTitle
                }).ToListAsync();

            return employeeDetails;
        }

        /// <summary>
        /// 5.	Вывести реквизит first_name сотрудников, которые живут в Europe(region_name)
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeEuropeDto>> GetEuropeEmployeeAsync()
        {
            var employee = await (
                from e in _context.Employees
                join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                join l in _context.Locations on d.LocationId equals l.LocationId
                join c in _context.Countries on l.CountryId equals c.CountryId
                join r in _context.Regions on c.RegionId equals r.RegionId
                where r.RegionName == "Европа"
                select new EmployeeEuropeDto
                {
                    FirstName = e.FirstName

                }).ToListAsync();

            return employee;
        }

        /// <summary>
        /// 6.	Получить детальную информацию о каждом сотруднике:First_name, Last_name, Departament, Job, Street, Country, Region
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeDetailDto>> GetEmployeeDetailsAsync()
        {
            var employee = await (
                from e in _context.Employees
                join j in _context.Jobs on e.JobId equals j.JobId
                join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                join l in _context.Locations on d.LocationId equals l.LocationId
                join c in _context.Countries on l.CountryId equals c.CountryId
                join r in _context.Regions on c.RegionId equals r.RegionId
                select new EmployeeDetailDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = d.DepartmentName,
                    JobTitle = j.JobTitle,
                    StreetAddress = l.StreetAddress,
                    CountryName = c.CountryName,
                    RegionName = r.RegionName
                }).ToListAsync();

            return employee;
        }
        
        /// <summary>
        /// 7.	Отразить регионы и количество сотрудников в каждом из них.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RegionsDto>> GetRegionEmployeeAsync()
        {
            var region = await (
                from e in _context.Employees
                join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                join l in _context.Locations on d.LocationId equals l.LocationId
                join c in _context.Countries on l.CountryId equals c.CountryId
                join r in _context.Regions on c.RegionId equals r.RegionId
                group e by r.RegionName into regionGroup
                select new RegionsDto
                {
                    RegionName = regionGroup.Key,
                    AverageEmployee = regionGroup.Count()
                }).ToListAsync();

            return region;
        }

        /// <summary>
        /// 8.	Вывести информацию по департаменту department_name с минимальной и максимальной зарплатой,
        /// с ранней и поздней датой прихода на работу и с количеством сотрудников. Сортировать по количеству сотрудников (по убыванию)
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentStatsDto>> GetDepartmentStatsAsync()
        {
            var departmentStats = await (
                from e in _context.Employees
                join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                join jh in _context.JobHistories on d.DepartmentId equals jh.DepartmentId
                group e by d.DepartmentName into departmentGroup
                select new DepartmentStatsDto
                {
                    DepartmentName = departmentGroup.Key, 
                    MinSalary = departmentGroup.Min(e => e.Salary), 
                    MaxSalary = departmentGroup.Max(e => e.Salary), 
                    StartDate = departmentGroup.Min(e => e.HireDate), 
                    EndDate = departmentGroup.Max(e => e.HireDate), 
                    EmployeeCount = departmentGroup.Count() 
                })
                .OrderByDescending(d => d.EmployeeCount) 
                .ToListAsync(); 

            return departmentStats;
        }

        
        /// <summary>
        /// 9.	Получить список реквизитов сотрудников FIRST_NAME, LAST_NAME и первые три цифры от номера телефона, если номер в формате ХХХ.ХХХ.ХХХХ
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeNumberDto>> GetEmployeeNumberAsync()
        {
            string phoneNumber = @"^\d{3}\.\d{3}\.\d{4}$";
            var employee = await (
                from e in _context.Employees
                where Regex.IsMatch(e.PhoneNumber, phoneNumber)
                select new EmployeeNumberDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PhoneNumber = e.PhoneNumber.Substring(0,3),

                }).ToListAsync();
            return employee;
        }

        
        /// <summary>
        /// 10.	Вывести список сотрудников, которые работают в департаменте администрирования доходов (departments.department_name = 'DAD')
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeDepartmentDadDto>> GetEmployeeDADAsync()
        {
            var employee = await (
                from e in _context.Employees
                join d in _context.Departments on e.DepartmentId equals d.DepartmentId
                where d.DepartmentName == "DAD"
                select new EmployeeDepartmentDadDto() { 
                    
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    HireDate = e.HireDate,
                    Salary = e.Salary,
                    ManagerId = e.ManagerId,
                    DepartmentName = d.DepartmentName
                }).ToListAsync();

            return employee;
        }
    }
}
