﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UpcountrySchoolRegistry.API.DataContracts.Requests;
using UpcountrySchoolRegistry.API.DataContracts.Responses;
using UpcountrySchoolRegistry.Business.Contracts.Services;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolServices _schoolServices;
        private readonly IMapper _mapper;
        private readonly ILogger<SchoolController> _logger;

        #region Constructor
        public SchoolController(ISchoolServices schoolServices, IMapper mapper, ILogger<SchoolController> logger)
        {
            this._schoolServices = schoolServices;
            this._mapper = mapper;
            this._logger = logger;
        }
        #endregion

        /// <summary>
        /// Obtem uma lista de escolas e permite consulta pelo nome ou endereço.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para montar a navegação e grid de consulta dos escolas cadastrados.
        /// 
        /// Sample request:
        ///
        ///     GET /api/school?filter=municipal
        ///
        /// </remarks>        
        [HttpGet]        
        [Produces("application/Json")]
        public async Task<List<SchoolResponse>> GetSchoolsAsync([FromQuery(Name = "filter")]string filter)
        {
            List<School> schools = await this._schoolServices.GetSchoolsAsync(filter);
            return this._mapper.Map<List<SchoolResponse>>(schools);
        }

        /// <summary>
        /// Obtem os detalhes do escola solicitado.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para uma exibição detalhada do escola.
        /// 
        /// 
        /// Sample request:
        ///
        ///     GET /api/school/1
        ///
        /// </remarks>        
        [HttpGet("{id}")]
        [Produces("application/Json")]
        public async Task<SchoolResponse> GetSchoolAsync(int id)
        {
            School school = await this._schoolServices.GetSchoolAsync(id);
            return this._mapper.Map<SchoolResponse>(school);
        }

        /// <summary>
        /// Cria um novo cadastro de escóla.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para a criação de um novo registro de escola.
        /// 
        /// 
        /// Sample request:
        ///
        ///     POST /api/school
        ///     {
        ///         "Name": "escola de Teste 1",
        ///         "Address": "Rue de Teste 1"
        ///     }
        ///
        /// </remarks>     
        [HttpPost]
        [Consumes("application/Json")]
        [Produces("application/Json")]
        public async Task<SchoolResponse> CreateSchool([FromBody]SchoolRequest schoolCreateRequest)
        {
            School newSchool = this._mapper.Map<School>(schoolCreateRequest);
            newSchool = await this._schoolServices.AddAsync(newSchool);

            return this._mapper.Map<SchoolResponse>(newSchool);
        }

        /// <summary>
        /// Atualiza os dados de um cadastro de escóla.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para a atualizar os dados de um registro de escola.
        /// 
        /// 
        /// Sample request:
        ///
        ///     PUT /api/school
        ///     {
        ///         "ID": 1,
        ///         "Name": "escola de Teste 1",
        ///         "Address": "Rue de Teste 1"
        ///     }
        ///
        /// </remarks>     
        [HttpPut("{id}")]
        [Consumes("application/Json")]
        public async Task<OkResult> UpdateSchool(int id, [FromBody] SchoolRequest schoolUpdateRequest)
        {
            School school = this._mapper.Map<School>(schoolUpdateRequest);
            school.ID = id;

            await this._schoolServices.UpdateAsync(school);
            return Ok();
        }

        /// <summary>
        /// Remove um cadastro de escóla.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para remover os dados de um registro de escola.
        /// 
        /// ATENÇÃO! Esse comando não será executado se o escola possuir turmas cadastradas.
        /// 
        /// 
        /// Sample request:
        ///
        ///     DELETE /api/school/1
        ///
        /// </remarks>     
        [HttpDelete("{id}")]
        [Consumes("application/Json")]
        public async Task<OkResult> DeleteSchool(int id)
        {
            await this._schoolServices.DeleteAsync(id);
            return Ok();
        }
    }
}
