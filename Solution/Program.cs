using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // Добавить это пространство имен
using Solution.Data;
using Solution.Interface;
using Solution.Repository;

namespace Solution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();

           
            builder.Services.AddDbContext<SolutionDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            
            builder.Services.AddScoped<IResultRepository, ResultRepository>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
