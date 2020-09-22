using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess.Base;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.Business.Contracts.DataAccess
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<List<Class>> GetClassesAsync(int schoolID, string filter);
        Task<Class> GetClassAsync(int ID);
        Class Add(Class schoolClass);
        void Update(Class schoolClass);
        void Delete(int ID);
    }
}
