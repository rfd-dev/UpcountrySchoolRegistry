using System;
using System.Collections.Generic;
using System.Text;
using UpcountrySchoolRegistry.Business.Contracts;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess.Base;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.Repository.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolRegistryContext _context;

        public IUnitOfWork UnitOfWork => _context;
        
        #region Constructor
        public SchoolRepository(SchoolRegistryContext context)
        {
            this._context = context;
        }
        #endregion

        public School Add(School school)
        {
            throw new NotImplementedException();
        }
    }
}
