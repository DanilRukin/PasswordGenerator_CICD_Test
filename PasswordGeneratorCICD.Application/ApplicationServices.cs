using Microsoft.Extensions.DependencyInjection;
using PasswordGeneratorCICD.Application.Dtos;
using PasswordGeneratorCICD.Application.Services.Interfaces;
using PasswordGeneratorCICD.Application.Services.Mappers;
using PasswordGeneratorCICD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordGeneratorCICD.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServices).GetTypeInfo().Assembly);
            })
                .AddMappers();
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            return services.AddScoped<IMapper<PasswordOptions, PasswordOptionsDto>, PasswordOptionsToPasswordOptionsDtoMapper>()
                .AddScoped<IMapper<PasswordOptionsDto, PasswordOptions>, PasswordOptionsDtoToPasswordOptionsMapper>();
        }
    }
}
