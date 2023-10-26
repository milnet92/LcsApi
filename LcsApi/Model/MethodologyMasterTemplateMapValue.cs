using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class MethodologyMasterTemplateMapValue
    {
        public int Id { get; set; }
        public int MethodologyId { get; set; }
        public string? TemplateId { get; set; }
        public int Version { get; set; }
        public object? PreviousVersions { get; set; }
    }
}
