using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;
using WebSite.Services.Abstractions;
using WebSite.Configurations;
using WebSite.Models.Requests;
using WebSite.Models.Responses;

namespace WebSite.Services
{
    public class GameService : IGameService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly RouteConfig _routeConfig;

        public GameService(IHttpClientService httpClientService, IOptions<Config> options)
        {
            _routeConfig = options.Value.WebSiteRoute;
            _httpClientService = httpClientService;
        }

        public async Task<GetByPageGameResponse> GetByPage(GetByPageProductRequest getByPageRequest)
        {
            var url = $"{_routeConfig.Game}GetByPage";
            var response = await _httpClientService.SendAsync<GetByPageGameResponse>(url, HttpMethod.Post, getByPageRequest);
            return response;
        }

        public async Task<GetByIdGameResponse> GetById(GetByIdProductRequest getByIdRequest)
        {
            var url = $"{_routeConfig.Game}GetById";
            var response = await _httpClientService.SendAsync<GetByIdGameResponse>(url, HttpMethod.Post, getByIdRequest);
            return response;
        }
    }
}
