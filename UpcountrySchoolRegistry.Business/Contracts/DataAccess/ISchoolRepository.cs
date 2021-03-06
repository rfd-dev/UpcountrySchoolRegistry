﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess.Base;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.Business.Contracts.DataAccess
{
    public interface ISchoolRepository : IRepository<School>
    {
        Task<List<School>> GetSchoolsAsync(string filter);
        Task<School> GetSchoolAsync(int ID);
        School Add(School school);
        void Update(School school);
        void Delete(int ID);
    }
}
