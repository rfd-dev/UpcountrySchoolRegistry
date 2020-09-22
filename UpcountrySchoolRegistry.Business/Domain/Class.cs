using System;
using System.Collections.Generic;
using System.Text;
using UpcountrySchoolRegistry.Business.Domain.Base;

namespace UpcountrySchoolRegistry.Business.Domain
{
    public class Class : Entity
    {
        public string Name { get; set; }

        public School School { get; set; }
    }
}
