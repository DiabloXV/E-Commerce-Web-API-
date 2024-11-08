
using Domain.Contracts;
using E_Commerce.API.Extensions;
using E_Commerce.API.Factories;
using E_Commerce.API.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Repositories;
using Services;
using Services.Abstractions;

namespace E_Commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Services
            
            builder.Services.AddCoreServices();

            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddPresentationServices();
            #endregion

            var app = builder.Build();

            #region Middlewares


            await app.SeedDbAsync();
            app.UseCustomExcdptionMiddleware();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles(); //if static files are in other place than default (wwwroot) -> new StaticFileOptions FileProvider = new PhysicalFileProvider("")

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #endregion

            app.Run();

        }

 
    }
}
