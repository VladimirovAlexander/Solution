using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Solution.Data;
using Solution.Dto;
using Solution.Interface;
using Solution.Models;

namespace Solution.Controllers
{
    [ApiController]
    [Route("api")]
    public class ResultController : Controller 
    {   
        private readonly IResultRepository _repo;
        public ResultController(IResultRepository repo) {

            _repo = repo;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var task1 = await _repo.GetEmployeeAsync();

            var task2 = await _repo.GetDataEmployeeAsync();

            var task3 = await _repo.GetCityAsync();

            var task4 = await _repo.GetRequisiteAsync();

            var task5 = await _repo.GetEuropeEmployeeAsync();

            var task6 = await _repo.GetEmployeeDetailsAsync();

            var task7 = await _repo.GetRegionEmployeeAsync();

            var task8 = await _repo.GetDepartmentStatsAsync();

            var task9 = await _repo.GetEmployeeNumberAsync();

            var task10 = await _repo.GetEmployeeDADAsync();

            var task = new TaskDto()
            {
                Task1 = task1,
                Task2 = task2,
                Task3 = task3,
                Task4 = task4,
                Task5 = task5,
                Task6 = task6,
                Task7 = task7,
                Task8 = task8,
                Task9 = task9,
                Task10 = task10

            };

            return View(task);
        }

    }
}
