using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess.Base;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.Repository.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly UpcountrySchoolRegistryContext _context;

        public IUnitOfWork UnitOfWork => _context;

        #region Constructor
        public ClassRepository(UpcountrySchoolRegistryContext context)
        {
            this._context = context;
        }
        #endregion

        public Class Add(Class schoolClass)
        {
            this._context.Attach(schoolClass.School);
            return this._context.Classes.Add(schoolClass).Entity;
        }

        public void Delete(int id)
        {
            this._context.Classes.Remove(new Class { ID = id });
        }

        public async Task<Class> GetClassAsync(int id)
        {
            return await this._context.Classes
                .Include(p => p.School)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.ID == id);
        }

        public async Task<List<Class>> GetClassesAsync(int schoolID, string filter)
        {
            return await this._context.Classes
                .Include(p => p.School)
                .AsNoTracking()
                .Where(c => c.School.ID == schoolID
                    && (string.IsNullOrEmpty(filter) || c.Name.Contains(filter)))
                .ToListAsync();
        }

        public void Update(Class schoolClass)
        {
            this._context.Attach(schoolClass.School);
            this._context.Classes.Update(schoolClass);
        }
    }
}
