using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.Business.Contracts.Services
{
    public interface ISchoolServices
    {
        Task<List<School>> GetSchoolsAsync(string filter);
        Task<School> GetSchoolAsync(int id);
        Task<School> AddAsync(School school);
        Task UpdateAsync(School school);
        Task DeleteAsync(int id);
    }
}
