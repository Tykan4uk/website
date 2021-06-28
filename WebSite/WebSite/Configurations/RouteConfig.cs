namespace WebSite.Configurations
{
    public class RouteConfig
    {
        private string _getByPageUrl;

        public string BaseUrl { get; set; }
        public string GetByPageUrl
        {
            get
            {
                return _getByPageUrl;
            }
            set
            {
                _getByPageUrl = $"{BaseUrl}{value}";
            }
        }
    }
}
