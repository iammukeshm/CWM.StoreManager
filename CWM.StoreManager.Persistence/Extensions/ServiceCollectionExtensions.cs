using CWM.StoreManager.Application.Abstractions.Persistence;
using CWM.StoreManager.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly(typeof(CatalogContext).Assembly.FullName)));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<CatalogContext>());
            services.AddScoped<IApplicationDbConnection, ApplicationDbConnection>();
            services.AddScoped<ICatalogContext, CatalogContext>();
        }
    }
}
