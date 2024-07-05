
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EmployeeWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
                


            //    (options =>
            //{
            //    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            //});

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EmployeeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("constr"));
            });

            //configure CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("clients-allowed", opts =>
                {
                    opts.WithOrigins("http://localhost:5077");
                    opts.AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("clients-allowed");

            app.Run();
        }
    }
}
