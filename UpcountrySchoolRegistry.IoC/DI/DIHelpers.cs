using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace UpcountrySchoolRegistry.IoC.DI
{
    public static class DIHelpers
    {
        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddDbContext<>
        }
    }
}
