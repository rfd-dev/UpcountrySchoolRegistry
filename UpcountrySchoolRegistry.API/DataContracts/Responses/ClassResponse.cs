using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpcountrySchoolRegistry.API.DataContracts.Responses
{
    public class ClassResponse
    {
        /// <example>
        /// 13
        /// </example>
        public int ID { get; set; }
        /// <example>
        /// 1
        /// </example>
        public int SchoolID { get; set; }

        /// <example>
        /// 7º Ano
        /// </example>
        public string Name { get; set; }
    }
}
