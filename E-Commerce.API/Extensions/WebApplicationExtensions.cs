﻿using E_Commerce.API.Middlewares;

namespace E_Commerce.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task <WebApplication> SeedDbAsync (this WebApplication app)
        {
            //Create Object from type that implements IDbInitializer
            using var scope = app.Services.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();

            await dbInitializer.InitializeAsync();
            return app;
        }

        public static WebApplication UseCustomExcdptionMiddleware (this WebApplication app) 
        {
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return app;
        }
    }
}
