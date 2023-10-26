using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class PagingParameters
    {
		public DynamicPaging? DynamicPaging { get; set; }
		public object? Filtering { get; set; }
    }
}