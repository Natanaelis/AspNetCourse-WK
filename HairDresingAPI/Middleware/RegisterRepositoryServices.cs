using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDresingAPI.Middleware
{
    public static class RegisterRepositoryServices
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<AvailableService>, Repository<AvailableService>>(); // dependency injection
            services.AddTransient<IRepository<Person>, Repository<Person>>(); // dependency injection
            services.AddTransient<IRepository<PersonType>, Repository<PersonType>>(); // dependency injection
            services.AddTransient<IRepository<Price>, Repository<Price>>(); // dependency injection
            services.AddTransient<IRepository<ServiceType>, Repository<ServiceType>>(); // dependency injection
            services.AddTransient<IRepository<Visit>, Repository<Visit>>(); // dependency injection
            //            services.AddScoped<IPricesRepository, PricesRepository>();
            //            services.AddSingleton<IPricesRepository, PricesRepository>();
            return services;
        }
    }
}
