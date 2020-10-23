using CWM.StoreManager.Application.Abstractions.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbConnection, ApplicationDbConnection>();

        }
    }
}
