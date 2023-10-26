using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class MethodologyMasterTemplate
    {
        public int MethodologyId { get; set; }
        public string? TemplateId { get; set; }
        public int Version { get; set; }
        public int TemplateState { get; set; }
        public int PublishedBy { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? VersionDescription { get; set; }
    }
}
