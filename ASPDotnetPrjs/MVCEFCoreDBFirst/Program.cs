using Microsoft.EntityFrameworkCore;
using MVCEFCoreDBFirst.Models;

namespace MVCEFCoreDBFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            

            //read the connection string from appSettings.json file
            var constr = builder.Configuration.GetConnectionString("sqlconstr");
            //register DbContext for injection into controllers
            builder.Services.AddDbContext<EmployeeDataContext>(options =>
                        options.UseSqlServer(constr)
                );
            
            //configure dependency injection for Repository class
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
            app.Run();
        }
    }
}
