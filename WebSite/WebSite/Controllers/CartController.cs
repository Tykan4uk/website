using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSite.Common.Enums;
using WebSite.Models.Requests;
using WebSite.Services.Abstractions;

namespace WebSite.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ILogger<GameCatalogController> _logger;
        private readonly ICartService _cartService;

        public CartController(ILogger<GameCatalogController> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }

        public async Task AddToCart(string productId, string name, string description, decimal price, ProductTypeEnum type)
        {
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            var request = new AddCartRequest()
            {
                UserId = userId,
                ProductId = productId,
                Name = name,
                Description = description,
                Price = price,
                Type = type
            };
            await _cartService.AddToCart(request);
        }

        public async Task<IActionResult> GetCart()
        {
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            var request = new GetCartRequest()
            {
                UserId = userId
            };
            var response = await _cartService.GetCart(request);
            return View(response);
        }

        public async Task RemoveFromCart(string productId)
        {
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            var request = new RemoveCartRequest()
            {
                UserId = userId,
                ProductId = productId
            };
            await _cartService.RemoveFromCart(request);
        }

        public async Task ClearCart()
        {
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            var request = new ClearCartRequest()
            {
                UserId = userId
            };
            await _cartService.ClearCart(request);
        }
    }
}
