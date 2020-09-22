using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.API.DataContracts.Responses;
using UpcountrySchoolRegistry.Business.Contracts.Services;
using UpcountrySchoolRegistry.Business.Domain;

namespace UpcountrySchoolRegistry.API.Controllers
{
    [Route("api/School")]
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
        [HttpGet("{schoolID}/class/{id}")]
        [Produces("application/Json")]
        public async Task<ClassResponse> GetSchoolAsync(int id)
        {
            Class schoolClass = await this._classServices.GetClassAsync(id);
            return this._mapper.Map <ClassResponse>(schoolClass);
        }
    }
}
