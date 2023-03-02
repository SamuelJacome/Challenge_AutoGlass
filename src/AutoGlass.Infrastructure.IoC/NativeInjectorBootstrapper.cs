using AutoGlass.Domain.Repositories;
using AutoGlass.Application.Services;
using AutoGlass.Application.Interfaces;
using AutoGlass.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AutoGlass.Infrastructure.IoC
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            /* Repositories */
            services.AddScoped<IProductRepository, ProductRepository>();

            /* Services */
            services.AddScoped<IProductAppService, ProductAppService>();
        }

    }

}