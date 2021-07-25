using WebSite.Common.Enums;

namespace WebSite.Models.Requests
{
    public class GetByPageProductRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public SortedTypeEnum SortedType { get; set; }
    }
}
