using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.Business.Contracts.Services
{
    public interface IClassServices
    {
        Task<List<Class>> GetClassesAsync(int schoolID, string filter);
        Task<Class> GetClassAsync(int id);
        Task<Class> AddAsync(Class schoolClass);
        Task UpdateAsync(Class schoolClass);
        Task DeleteAsync(int id);
    }
}
