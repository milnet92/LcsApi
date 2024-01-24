using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LcsApi.Model.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LcsApi.Model
{
    public class OrganizationReference
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrganizationType? OrganizationType { get; set; }

        public string RedirectUrl { get; set; }
    }
}
