﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UpcountrySchoolRegistry.API.DataContracts.Requests
{
    public class ClassRequest
    {
        /// <example>
        /// Quimica Basica
        /// </example>
        [Required(ErrorMessage = "{0} é obrigatório")]
        [MaxLength(255, ErrorMessage = "Tamanho máximo do campo {0}: 255 posições ")]
        public string Name { get; set; }
    }
}
