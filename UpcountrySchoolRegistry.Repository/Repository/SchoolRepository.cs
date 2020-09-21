using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Business.Contracts;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess.Base;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.Repository.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly UpcountrySchoolRegistryContext _context;

        public IUnitOfWork UnitOfWork => _context;
        
        #region Constructor
        public SchoolRepository(UpcountrySchoolRegistryContext context)
        {
            this._context = context;
        }
        #endregion

        public School Add(School school)
        {
            return this._context.Schools.Add(school).Entity;
        }

        public async Task<List<School>> GetSchoolsAsync(string filter)
        {
            return await this._context.Schools
                .AsNoTracking()
                .Where(school =>
                    school.Name.Contains(filter, StringComparison.CurrentCultureIgnoreCase)
                ||  school.Address.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                .ToListAsync();
        }

        public async Task<School> GetSchoolAsync(int id)
        {
            return await this._context.Schools.AsNoTracking().SingleOrDefaultAsync(school => school.ID == id);
        }

        public void Update(School school)
        {
            this._context.Schools.Update(school);
        }

        public void Delete(int id)
        {
            this._context.Schools.Remove(new School { ID = id });
        }
    }
}
