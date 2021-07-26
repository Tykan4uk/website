using System.Collections.Generic;

namespace WebSite.Models.Requests
{
    public class AddOrderRequest
    {
        public string UserId { get; set; }
        public List<CartProductModel> Products { get; set; }
    }
}
