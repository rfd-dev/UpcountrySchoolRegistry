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
    public class ClassServices : IClassServices
    {
        private readonly IClassRepository _classRepository;
        private readonly ILogger<ClassServices> _logger;
        #region Constructor
        public ClassServices(IClassRepository classRepository, ILogger<ClassServices> logger)
        {
            this._classRepository = classRepository;
            this._logger = logger;
        }
        #endregion

        public async Task<Class> AddAsync(Class schoolClass)
        {
            schoolClass = this._classRepository.Add(schoolClass);
            await this._classRepository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation("Novo turma cadastrada com o ID {id}", schoolClass.ID);
            return schoolClass;
        }

        public async Task DeleteAsync(int id)
        {
            this._classRepository.Delete(id);
            await this._classRepository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(" Turma cadastrada com o ID {id} foi removida com sucesso", id);
        }

        public async Task<List<Class>> GetClassesAsync(string filter)
        {
            return await this._classRepository.GetClassesAsync(filter);
        }

        public async Task<Class> GetClassesAsync(int id)
        {
            return await this._classRepository.GetClassAsync(id);
        }

        public async Task UpdateAsync(Class schoolClass)
        {
            this._classRepository.Update(schoolClass);
            await this._classRepository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation("Dados da turma cadastrada com o ID {id} atualizados com sucesso.", schoolClass.ID);
        }
    }
}
