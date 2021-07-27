using System.Collections.Generic;

namespace WebSite.Models
{
    public class GetByIdOrderViewModel
    {
        public string OrderId { get; set; }
        public List<CartProductModel> Products { get; set; }
    }
}
