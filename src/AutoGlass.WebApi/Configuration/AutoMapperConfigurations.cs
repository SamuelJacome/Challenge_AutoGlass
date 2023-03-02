
using Microsoft.Extensions.DependencyInjection;
using AutoGlass.Application.Mappers;

namespace AutoGlass.WebApi.Configuration
{
    public static class AutoMapperConfigurations
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ModelToViewModelMapper),
                typeof(ViewModelToModelMapper)
            );
        }
    }
}