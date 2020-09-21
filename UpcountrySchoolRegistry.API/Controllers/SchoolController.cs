using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        /// Obtem uma lista de colegios e permite consulta pelo nome ou endereço.
        /// </summary>
        /// <remarks>
        /// Utilize essa chamada para montar a navegação e grid de consulta dos colégios cadastrados
        /// Sample request:
        ///
        ///     GET /school?filter=municipal
        ///
        /// </remarks>        
        [HttpGet]        
        [Produces("application/Json")]
        public async Task<List<SchoolResponse>> GetSchoolsAsync([FromQuery(Name = "filter")]string filter)
        {
            List<School> schools = await this._schoolServices.GetSchoolsAsync(filter);
            return this._mapper.Map<List<SchoolResponse>>(schools);
        }
    }
}
