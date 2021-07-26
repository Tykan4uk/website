namespace WebSite.Models.Requests
{
    public class GetByPageOrderRequest
    {
        public string UserId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
