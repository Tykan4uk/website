using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebSite.Configurations;
using WebSite.Models;
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

        public async Task<AddCartResponse> AddToCart(int userId, int gameId)
        {
            string url = $"{_routeConfig.Cart}Add?userId={userId}&gameId={gameId}";
            var response = await _httpClientService.SendAsync<AddCartResponse>(url, HttpMethod.Post);
            return response;
        }

        public async Task<List<GameViewModel>> GetCart(int userId)
        {
            string urlCartApi = $"{_routeConfig.Cart}?userId={userId}";
            var listId = await _httpClientService.SendAsync<GetCartResponse>(urlCartApi, HttpMethod.Post);
            return new List<GameViewModel>();
        }

        public async Task<RemoveCartResponse> RemoveFromCart(int userId, int gameId)
        {
            string url = $"{_routeConfig.Cart}Remove?userId={userId}&gameId={gameId}";
            var response = await _httpClientService.SendAsync<RemoveCartResponse>(url, HttpMethod.Post);
            return response;
        }
    }
}
