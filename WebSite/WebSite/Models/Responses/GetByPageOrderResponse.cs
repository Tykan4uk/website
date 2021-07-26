using System.Collections.Generic;

namespace WebSite.Models.Responses
{
    public class GetByPageOrderResponse
    {
        public IEnumerable<OrderModel> Orders { get; set; }
        public int TotalRecords { get; set; }
    }
}
