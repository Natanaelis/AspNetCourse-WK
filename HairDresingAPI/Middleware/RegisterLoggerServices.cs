using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using HairDresingAPI.Controllers;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDresingAPI.Middleware
{
    public static class RegisterLoggerServices
    {
        public static IServiceCollection AddLoggers(this IServiceCollection services)
        {
//            services.AddLogger<AvailableServicesController>();
            return services;
        }
    }
}
