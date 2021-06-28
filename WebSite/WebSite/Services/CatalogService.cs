using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using WebSite.Services.Abstractions;
using WebSite.Models;
using WebSite.Configurations;

namespace WebSite.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly RouteConfig _routeConfig;

        public CatalogService(IHttpClientService httpClientService, IOptions<RouteConfig> options)
        {
            _routeConfig = options.Value;
            _httpClientService = httpClientService;
        }

        public async Task<List<GameEntity>> GetByPage(int page)
        {
            string url = $"{_routeConfig.GetByPageUrl}?page={page}";
            var response = await _httpClientService.SendAsync<List<GameEntity>>(url, HttpMethod.Get);
            return response;
        }
    }
}
