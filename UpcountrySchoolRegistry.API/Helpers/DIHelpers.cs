﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Repository;

namespace UpcountrySchoolRegistry.API.Helpers
{
    public static class DIHelpers
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UpcountrySchoolRegistryContext>(options =>
                         options.UseSqlServer(configuration.GetConnectionString("SqlConnection")), ServiceLifetime.Scoped);
        }
    }
}
