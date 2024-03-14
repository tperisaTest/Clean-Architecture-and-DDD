using BuberDinner.Infrastructure.Authentication;
﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BuberDinner.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
        {
            services.Configure<JwtTokenOptions>(config.GetSection(JwtTokenOptions.SectionName));
            return services;
        }
    }
}
