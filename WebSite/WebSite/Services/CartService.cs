using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebSite.Configurations;
using WebSite.Models.Requests;
using WebSite.Models.Responses;
using WebSite.Services.Abstractions;

namespace WebSite.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly RouteConfig _routeConfig;

        public CartService(IHttpClientService httpClientService, IOptions<Config> options)
        {
            _routeConfig = options.Value.WebSiteRoute;
            _httpClientService = httpClientService;
        }

        public async Task<AddCartResponse> AddToCart(AddCartRequest addCartRequest)
        {
            string url = $"{_routeConfig.Cart}Add";
            var response = await _httpClientService.SendAsync<AddCartResponse>(url, HttpMethod.Post, addCartRequest);
            return response;
        }

        public async Task<GetCartResponse> GetCart(GetCartRequest getCartRequest)
        {
            string urlCartApi = $"{_routeConfig.Cart}Get";
            var response = await _httpClientService.SendAsync<GetCartResponse>(urlCartApi, HttpMethod.Post, getCartRequest);
            return response;
        }

        public async Task<RemoveCartResponse> RemoveFromCart(RemoveCartRequest removeCartRequest)
        {
            string url = $"{_routeConfig.Cart}Remove";
            var response = await _httpClientService.SendAsync<RemoveCartResponse>(url, HttpMethod.Post, removeCartRequest);
            return response;
        }
    }
}
