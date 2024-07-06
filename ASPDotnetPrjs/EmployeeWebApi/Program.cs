
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

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

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                //parameters for token validation
                var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience= builder.Configuration["JWT:Audience"],
                    IssuerSigningKey=new SymmetricSecurityKey(key)
                };
            });

            //add the global exception handler middlewere
            builder.Services.AddScoped<GlobalExceptionHandler>();

            //builder.Services.AddLogging(options =>
            //{
            //    //configure the options like file path
               
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseAuthorization();


            app.MapControllers();

            app.UseCors("clients-allowed");

            app.UseAuthentication(); //sequence shud be this only
            app.UseAuthorization();


            //use the GlobalException middleware
            app.UseMiddleware<GlobalExceptionHandler>();
            app.Run();
        }
    }
}
