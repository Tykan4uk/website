using WebSite.Common.Enums;

namespace WebSite.Models.Requests
{
    public class AddCartRequest
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductTypeEnum Type { get; set; }
    }
}
