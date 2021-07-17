using System.Collections.Generic;

namespace WebSite.Models.Responses
{
    public class GetByPageRelatedProductResponse
    {
        public IEnumerable<RelatedProductViewModel> RelatedProducts { get; set; }
        public int TotalRecords { get; set; }
    }
}
