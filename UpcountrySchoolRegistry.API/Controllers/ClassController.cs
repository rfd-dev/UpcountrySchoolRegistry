using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.API.DataContracts.Requests;
using UpcountrySchoolRegistry.API.DataContracts.Responses;
using UpcountrySchoolRegistry.Business.Contracts.Services;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.API.Controllers
{
    [Route("api/School/{schoolID}/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassServices _classServices;
        private readonly IMapper _mapper;
        private readonly ILogger<ClassController> _logger;

        #region Constructor
        public ClassController(IClassServices classServices, IMapper mapper, ILogger<ClassController> logger)
        {
            this._classServices = classServices;
            this._mapper = mapper;
            this._logger = logger;
        }
        #endregion

        /// <summary>
        /// Obtem as turmas cadastradas para uma escola.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para montar a navegação e grid de consulta dos turmas de uma determinada esocla.
        /// 
        /// Sample request:
        ///
        ///     GET /api/school/1/class?filter=5
        ///
        /// </remarks>        
        [HttpGet]
        [Produces("application/Json")]
        public async Task<List<ClassResponse>> GetSchoolsAsync(int schoolID, [FromQuery(Name = "filter")] string filter)
        {
            List<Class> classes = await this._classServices.GetClassesAsync(schoolID, filter);
            return this._mapper.Map<List<ClassResponse>>(classes);
        }

        /// <summary>
        /// Obtem os detalhes da turma solicitada.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para uma exibição detalhada de uma turma de uma escola.
        /// 
        /// 
        /// Sample request:
        ///
        ///     GET /api/school/1/class/13
        ///
        /// </remarks>        
        [HttpGet("{id}")]
        [Produces("application/Json")]
        public async Task<ClassResponse> GetClassAsync(int id)
        {
            Class schoolClass = await this._classServices.GetClassAsync(id);
            return this._mapper.Map <ClassResponse>(schoolClass);
        }

        /// <summary>
        /// Cria um nova turma em uma escola.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para a criação de uma nova turma dentro de uma escola.
        /// 
        /// 
        /// Sample request:
        ///
        ///     POST /api/school/1/class
        ///     {
        ///         "Name": "Inglês Basico",
        ///     }
        ///
        /// </remarks>     
        [HttpPost]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        public async Task<ClassResponse> CreateSchool(int schoolID, [FromBody] ClassRequest classRequest)
        {   
            Class newClass = this._mapper.Map<Class>(classRequest);
            newClass.School = new School { ID = schoolID };

            newClass = await this._classServices.AddAsync(newClass);

            return this._mapper.Map<ClassResponse>(newClass);
        }

        ///// <summary>
        ///// Atualiza os dados de um cadastro de escóla.
        ///// </summary>
        ///// <remarks>
        ///// Utilize essa chamada para a atualizar os dados de um registro de escola.
        ///// 
        ///// 
        ///// Sample request:
        /////
        /////     PUT /api/school
        /////     {
        /////         "ID": 1,
        /////         "Name": "escola de Teste 1",
        /////         "Address": "Rue de Teste 1"
        /////     }
        /////
        ///// </remarks>     
        //[HttpPut]
        //[Consumes("application/Json")]
        //public async Task<OkResult> UpdateSchool([FromBody] SchoolUpdateRequest schoolUpdateRequest)
        //{
        //    School newSchool = this._mapper.Map<School>(schoolUpdateRequest);
        //    await this._schoolServices.UpdateAsync(newSchool);

        //    return Ok();
        //}

        ///// <summary>
        ///// Remove um cadastro de escóla.
        ///// </summary>
        ///// <remarks>
        ///// Utilize essa chamada para remover os dados de um registro de escola.
        ///// 
        ///// ATENÇÃO! Esse comando não será executado se o escola possuir turmas cadastradas.
        ///// 
        ///// 
        ///// Sample request:
        /////
        /////     DELETE /api/school/1
        /////
        ///// </remarks>     
        //[HttpDelete("{id}")]
        //[Consumes("application/Json")]
        //public async Task<OkResult> DeleteSchool(int id)
        //{
        //    await this._schoolServices.DeleteAsync(id);
        //    return Ok();
        //}
    }
}
