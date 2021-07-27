using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebSite.Configurations;
using WebSite.Models.Requests;
using WebSite.Models.Responses;
using WebSite.Services.Abstractions;

namespace WebSite.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly RouteConfig _routeConfig;

        public OrderService(IHttpClientService httpClientService, IOptions<Config> options)
        {
            _routeConfig = options.Value.WebSiteRoute;
            _httpClientService = httpClientService;
        }

        public async Task<AddOrderResponse> AddOrder(AddOrderRequest addOrderRequest)
        {
            string url = $"{_routeConfig.Order}Add";
            var response = await _httpClientService.SendAsync<AddOrderResponse>(url, HttpMethod.Post, addOrderRequest);
            return response;
        }

        public async Task<GetByPageOrderResponse> GetByPageOrder(GetByPageOrderRequest getByPageOrderRequest)
        {
            string urlCartApi = $"{_routeConfig.Order}GetByPage";
            var response = await _httpClientService.SendAsync<GetByPageOrderResponse>(urlCartApi, HttpMethod.Post, getByPageOrderRequest);
            return response;
        }

        public async Task<GetByIdOrderResponse> GetByIdOrder(GetByIdOrderRequest getByIdOrderRequest)
        {
            string url = $"{_routeConfig.Order}GetById";
            var response = await _httpClientService.SendAsync<GetByIdOrderResponse>(url, HttpMethod.Post, getByIdOrderRequest);
            return response;
        }
    }
}
