using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess.Base;
using UpcountrySchoolRegistry.Business.Domain;
using UpcountrySchoolRegistry.Repository.Configuration;

namespace UpcountrySchoolRegistry.Repository
{
    public class SchoolRegistryContext : DbContext, IUnitOfWork
    {
        public DbSet<School> Schools { get; set; }

        #region Constructor
        public SchoolRegistryContext(DbContextOptions<SchoolRegistryContext> options) : base(options) { }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações Default
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                property.SetIsUnicode(false); // Configurando o EFC para criar os campos como VARCHAR e não como NVARCHAR.
            }

            // Configurações Especificas
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
        }
    }
}
