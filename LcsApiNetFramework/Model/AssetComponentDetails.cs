using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class AssetComponentDetail
    {
        public Guid FileAssetId { get; set; }
        public int FileTypepropertyId { get; set; }
        public string FileTypePropertyName { get; set; }
        public Guid Id { get; set; }
        public DateTime? LocalCreatedDate { get; set; }
        public DateTime? LocalModifiedDate { get; set; }
        public int PropertyType { get; set; }
        public string PropertyValue { get; set; }
    }
}
