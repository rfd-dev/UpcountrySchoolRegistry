using System;
using System.Collections.Generic;
using System.Text;
using UpcountrySchoolRegistry.Business.Domain.Base;

namespace UpcountrySchoolRegistry.Business.Domain
{
    public class School : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
