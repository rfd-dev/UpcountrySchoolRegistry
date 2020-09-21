using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpcountrySchoolRegistry.API.DataContracts.Responses
{
    public class SchoolResponse
    {
        /// <example>
        /// 1
        /// </example>
        public int ID { get; set; }

        /// <example>
        /// Colégio Santa Clara
        /// </example>
        public string Name { get; set; }
        
        /// <example>
        /// Rua Sete de Setembro, 145
        /// </example>
        public string Address { get; set; }
    }
}
