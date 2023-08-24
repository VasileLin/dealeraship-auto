using DealershipAuto_Manager.Middleware;
using DealershipAuto_Manager.Repositories;
using DealershipAuto_Manager.Services;
using Microsoft.AspNetCore.Diagnostics;

namespace DealershipAuto_Manager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ExceptionHandlingMiddleware>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICarRepository, InMemoryCarRepository>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IClientRepository, InMemoryClientRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            

            app.Run();
        }
    }
}