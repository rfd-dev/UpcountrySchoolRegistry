using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.Business.Contracts.DataAccess;
using UpcountrySchoolRegistry.Business.Contracts.Services;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.Business.Services
{
    public class SchoolServices : ISchoolServices
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly ILogger<SchoolServices> _logger;

        #region Construtor
        public SchoolServices(ISchoolRepository schoolRepository, ILogger<SchoolServices> logger)
        {
            this._schoolRepository = schoolRepository;
            this._logger = logger;
        }
        #endregion

        public async Task<School> AddAsync(School school)
        {
            School newSchool = this._schoolRepository.Add(school);
            await this._schoolRepository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation("Novo escola cadastrado com o ID {id}", newSchool.ID);
            return newSchool;
        }

        public async Task DeleteAsync(int id)
        {
            this._schoolRepository.Delete(id);
            await this._schoolRepository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(" escola cadastrado com o ID {id} foi removido com sucesso", id);
        }

        public async Task<School> GetSchoolAsync(int id)
        {
            return await this._schoolRepository.GetSchoolAsync(id);
        }

        public async Task<List<School>> GetSchoolsAsync(string filter)
        {
            return await this._schoolRepository.GetSchoolsAsync(filter);
        }

        public async Task UpdateAsync(School school)
        {
            this._schoolRepository.Update(school);
            await this._schoolRepository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation("Dados do escola cadastrado com o ID {id} atualizados com sucesso.", school.ID);
        }
    }
}
