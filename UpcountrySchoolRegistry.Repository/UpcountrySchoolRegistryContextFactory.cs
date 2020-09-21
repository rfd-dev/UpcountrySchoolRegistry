using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.Repository
{
    /// <summary>
    /// Classe necessaria para ajudar o EF Migrations a realizar as migrações em um porjeto fora do starter
    /// </summary>
    public class UpcountrySchoolRegistryContextFactory : IDesignTimeDbContextFactory<UpcountrySchoolRegistryContext>
    {
        public UpcountrySchoolRegistryContext CreateDbContext(string[] args)
        {
            //string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //               .AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true)
            //               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<UpcountrySchoolRegistryContext>();
            optionsBuilder.UseSqlServer(@"Data Source=MNF007\SQLEXPRESS;Initial Catalog=UpcountrySchoolRegistry;Integrated Security=SSPI;");

            return new UpcountrySchoolRegistryContext(optionsBuilder.Options);
        }
    }
}
