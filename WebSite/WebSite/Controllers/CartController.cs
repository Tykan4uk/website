using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSite.Services.Abstractions;

namespace WebSite.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ICartService _cartService;

        public CartController(ILogger<CatalogController> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }

        public async Task AddToCart(int gameId)
        {
            await _cartService.AddToCart(1, gameId);
        }

        public async Task<IActionResult> GetCart()
        {
            var response = await _cartService.GetCart(1);
            return View(response);
        }

        public async Task RemoveFromCart(int gameId)
        {
            await _cartService.RemoveFromCart(1, gameId);
        }
    }
}
