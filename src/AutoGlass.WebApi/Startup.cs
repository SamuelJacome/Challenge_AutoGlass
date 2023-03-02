using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoGlass.Domain.Validations;
using AutoGlass.Infrastructure.IoC;
using AutoGlass.WebApi.Configuration;
using AutoGlass.WebApi.Converters;
using AutoGlass.WebApi.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AutoGlass.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddFluentValidation(config =>
            config.RegisterValidatorsFromAssemblyContaining<ProductValidation>()
            ).AddJsonOptions(options =>
            {
                // options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                // options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutoGlass.WebApi", Version = "v1" });
            });
            services.AddAutoMapperConfiguration();
            services.AddPersistence(Configuration);
            services.RegisterServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoGlass.WebApi v1"));
            }



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.ConfigureExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
