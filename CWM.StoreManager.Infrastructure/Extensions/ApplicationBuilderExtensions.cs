using Microsoft.AspNetCore.Builder;

namespace CWM.StoreManager.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSwaggerService(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CWM Store Manager API");
                options.RoutePrefix = "swagger";
                options.DisplayRequestDuration();
            });
        }
    }
}