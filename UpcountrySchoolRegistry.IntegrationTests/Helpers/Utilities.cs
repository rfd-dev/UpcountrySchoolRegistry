using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UpcountrySchoolRegistry.Business.Domain;
using UpcountrySchoolRegistry.Repository;

namespace UpcountrySchoolRegistry.IntegrationTests.Helpers
{
    public class Utilities
    {
        public static void InitializeDbForTests(UpcountrySchoolRegistryContext db)
        {
            db.Schools.AddRange(SeedSchools());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(UpcountrySchoolRegistryContext db)
        {
            db.Schools.RemoveRange(db.Schools);
            InitializeDbForTests(db);
        }

        public static List<School> SeedSchools()
        {
            return new List<School>()
            {
                new School { ID = 1, Name = "Colégio de Aplicação da UFPE", Address = "Recife" },
                new School { ID = 2, Name = "Colégio Estadual Waldemiro Pitta", Address = "Cambuci" },
                new School { ID = 3, Name = "Colégio Estadual Oscar Batista", Address = "Cambuci" }
            };
        }
    }
}
