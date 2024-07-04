using Microsoft.EntityFrameworkCore;
using MVCEFCoreCodeFirst.Models;

namespace MVCEFCoreCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //register the DbContext class
            builder.Services.AddDbContext<CustomerDBContext>(options =>
            {
                options.UseSqlServer("Data Source=RAMASUS;Initial Catalog=VSMDB_CF;Integrated Security=True;Encrypt=False");
            });

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
