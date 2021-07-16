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

        public CatalogService(IHttpClientService httpClientService, IOptions<Config> options)
        {
            _routeConfig = options.Value.WebSiteRoute;
            _httpClientService = httpClientService;
        }

        public async Task<List<GameViewModel>> GetByPage(int page)
        {
            string url = $"{_routeConfig.Game}GetByPage?page={page}";
            var response = await _httpClientService.SendAsync<List<GameViewModel>>(url, HttpMethod.Post);
            return response;
        }
    }
}
