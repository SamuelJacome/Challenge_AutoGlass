

using AutoGlass.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoGlass.WebApi.Configuration
{
    public static class PersistenceConfigurations
    {
        public static void AddPersistence(this IServiceCollection services,
                                        IConfiguration configuration)
        {
            services.AddDbContext<AutoGlassContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}