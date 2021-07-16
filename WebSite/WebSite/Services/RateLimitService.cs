using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebSite.Configurations;
using WebSite.Models.Responses;
using WebSite.Services.Abstractions;

namespace WebSite.Services
{
    public class RateLimitService : IRateLimitService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly RouteConfig _routeConfig;

        public RateLimitService(IHttpClientService httpClientService, IOptions<Config> options)
        {
            _routeConfig = options.Value.WebSiteRoute;
            _httpClientService = httpClientService;
        }

        public async Task<CheckRateLimitResponse> CheckRateLimit(string name)
        {
            string url = $"{_routeConfig.RateLimit}CheckRateLimit?name={name}";
            var response = await _httpClientService.SendAsync<CheckRateLimitResponse>(url, HttpMethod.Post);
            return response;
        }
    }
}
