using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UpcountrySchoolRegistry.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UpcountrySchoolRegistry.IntegrationTests.Helpers;

namespace UpcountrySchoolRegistry.IntegrationTests
{
    public class InMemoryDbWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Removendo o bind ao DbContext da aplicação.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<UpcountrySchoolRegistryContext>));

                services.Remove(descriptor);

                services.AddDbContext<UpcountrySchoolRegistryContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDb");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<UpcountrySchoolRegistryContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<InMemoryDbWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Falha na inicialização do DB " + "database with test messages. Error: {Message}", ex.Message);
                    }
                }
            });
        }
    }
}
