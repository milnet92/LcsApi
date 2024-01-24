namespace LcsApi.Model.Common
{
    public class PaginatedResponse<T>
    {
        public int PagingType { get; set; }
        public T[] Results { get; set; }
        public int StartIndex { get; set; }
        public int TotalCount { get; set; }
    }
}