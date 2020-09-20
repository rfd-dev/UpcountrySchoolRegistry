using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Commons.Settings;

namespace UpcountrySchoolRegistry.API.Helpers
{
    public static class ConfigurationHelpers
    {
		public static void CustomizeSwaggerGen(this IServiceCollection services, SwaggerOptions appSettings)
        {
            // TODO: Pegar textos do arquivo de configuração
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = appSettings.Version,
                    Title = appSettings.Title,
                    Description = appSettings.Description,
                    Contact = new OpenApiContact
                    {
                        Name = appSettings.ContactName,
                        Email = appSettings.ContactEmail,
                    },
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void ConfigureSerilog(this IServiceCollection services)
        {

        }
	}
}
