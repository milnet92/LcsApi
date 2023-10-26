using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class SqlAction
    {
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? AccessLevel { get; set; }
        public object? QueryTemplate { get; set; }
        public object[]? Parameters { get; set; }
        public bool? Active { get; set; }
        public bool? FastQuery { get; set; }
        public bool? SupportsAllQueryPaths { get; set; }
        public string? DeploymentItemName { get; set; }
        public int? QueryTimeout { get; set; }
        public bool? ReturnsResults { get; set; }
        public object? OutputFileExtension { get; set; }
        public string[]? Audience { get; set; }
    }
}
