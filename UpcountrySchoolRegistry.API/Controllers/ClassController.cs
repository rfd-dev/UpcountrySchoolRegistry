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
        public async Task<List<ClassResponse>> GetClassesAsync(int schoolID, [FromQuery(Name = "filter")] string filter)
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
        public async Task<ClassResponse> CreateClass(int schoolID, [FromBody] ClassRequest classRequest)
        {   
            Class newClass = this._mapper.Map<Class>(classRequest);
            newClass.School = new School { ID = schoolID };

            newClass = await this._classServices.AddAsync(newClass);

            return this._mapper.Map<ClassResponse>(newClass);
        }

        /// <summary>
        /// Atualiza os dados de um turma.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para a atualizar os dados de uma turma.
        /// 
        /// 
        /// Sample request:
        ///
        ///     PUT /api/school/1/Class/13
        ///     {
        ///         "Name": "Turma Adiada",
        ///     }
        ///
        /// </remarks>     
        [HttpPut("{id}")]
        [Consumes("application/Json")]
        public async Task<OkResult> UpdateClass(int id, int schoolID, [FromBody] ClassRequest classRequest)
        {
            Class schoolClass = this._mapper.Map<Class>(classRequest);
            schoolClass.ID = id;
            schoolClass.School = new School { ID = schoolID };

            await this._classServices.UpdateAsync(schoolClass);
            return Ok();
        }

        /// <summary>
        /// Remove um turma cadastrada para uma escóla.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para remover os dados de uma turma.
        /// 
        /// 
        /// Sample request:
        ///
        ///     DELETE /api/school/1/class/13
        ///
        /// </remarks>     
        [HttpDelete("{id}")]
        [Consumes("application/Json")]
        public async Task<OkResult> DeleteClass(int id)
        {
            await this._classServices.DeleteAsync(id);
            return Ok();
        }
    }
}
