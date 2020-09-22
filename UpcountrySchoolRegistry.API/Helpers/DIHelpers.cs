using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess;
using UpcountrySchoolRegistry.Business.Contracts.Services;
using UpcountrySchoolRegistry.Business.Services;
using UpcountrySchoolRegistry.Repository;
using UpcountrySchoolRegistry.Repository.Repository;

namespace UpcountrySchoolRegistry.API.Helpers
{
    public static class DIHelpers
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UpcountrySchoolRegistryContext>(options =>
                         options.UseSqlServer(configuration["ContextConnectionString"]), ServiceLifetime.Scoped);

            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();

            services.AddTransient<ISchoolServices, SchoolServices>();
            services.AddTransient<IClassServices, ClassServices>();
        }

        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            // CORS Configuration
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
