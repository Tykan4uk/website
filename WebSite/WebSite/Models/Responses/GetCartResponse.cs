using System.Collections.Generic;

namespace WebSite.Models.Responses
{
    public class GetCartResponse
    {
        public List<CartProductModel> CartProducts { get; set; } = null!;
    }
}
