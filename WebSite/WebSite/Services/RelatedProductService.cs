using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebSite.Configurations;
using WebSite.Models.Requests;
using WebSite.Models.Responses;
using WebSite.Services.Abstractions;

namespace WebSite.Services
{
    public class RelatedProductService : IRelatedProductService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly RouteConfig _routeConfig;

        public RelatedProductService(IHttpClientService httpClientService, IOptions<Config> options)
        {
            _routeConfig = options.Value.WebSiteRoute;
            _httpClientService = httpClientService;
        }

        public async Task<GetByPageRelatedProductResponse> GetByPage(GetByPageProductRequest getByPageRequest)
        {
            var url = $"{_routeConfig.RelatedProduct}GetByPage";
            var response = await _httpClientService.SendAsync<GetByPageRelatedProductResponse>(url, HttpMethod.Post, getByPageRequest);
            return response;
        }
    }
}
