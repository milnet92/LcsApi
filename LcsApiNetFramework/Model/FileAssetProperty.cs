using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class FileAssetProperty
    {
        public Guid Id { get; set; }
        public Guid? FileAssetId { get; set; }
        public int FileTypePropertyId { get; set; }
        public object FileTypePropertyName { get; set; }
        public int? PropertyValueId { get; set; }
        public string PropertyValue { get; set; }
        public string PropertyValueDisplay { get; set; }
        public object PropertyValueJson { get; set; }
        public int PropertyType { get; set; }
        public string TelemetryId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public object LocalCreatedDate { get; set; }
        public object LocalModifiedDate { get; set; }
    }

}
