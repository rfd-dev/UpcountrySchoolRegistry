using System;
using System.Collections.Generic;
using System.Text;

namespace UpcountrySchoolRegistry.Commons.Settings
{
    public class SwaggerOptions
    {
        public const string Key = "Swagger";

        public string Description { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
    }
}
