using System.Collections.Generic;

namespace WebSite.Models.Responses
{
    public class GetByPageRelatedProductResponse
    {
        public IEnumerable<RelatedProductModel> RelatedProducts { get; set; }
        public int TotalRecords { get; set; }
    }
}
