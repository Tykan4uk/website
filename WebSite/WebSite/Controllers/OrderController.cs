using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebSite.Configurations;
using WebSite.Models;
using WebSite.Models.Requests;
using WebSite.Services.Abstractions;

namespace WebSite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly WebSiteConfig _options;

        public OrderController(
            IOrderService orderService,
            IOptions<Config> options,
            ILogger<OrderController> logger,
            ICartService cartService)
        {
            _orderService = orderService;
            _options = options.Value.WebSiteConfig;
            _logger = logger;
            _cartService = cartService;
        }

        public async Task Add()
        {
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            var getCartRequest = await _cartService.GetCart(new GetCartRequest() { UserId = userId });
            var request = new AddOrderRequest()
            {
                UserId = userId,
                Products = getCartRequest.CartProducts
            };
            await _orderService.AddOrder(request);
        }

        public async Task<IActionResult> GetByPage(int page)
        {
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            var request = new GetByPageOrderRequest()
            {
                UserId = userId,
                Page = page,
                PageSize = _options.PageSize,
            };
            var response = await _orderService.GetByPageOrder(request);
            await Task.Delay(1000);
            return View(response);
        }

        public async Task<IActionResult> GetById(string orderId)
        {
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            var request = new GetByIdOrderRequest()
            {
                UserId = userId,
                OrderId = orderId
            };
            var response = await _orderService.GetByIdOrder(request);
            var view = new GetByIdOrderViewModel()
            {
                OrderId = orderId,
                Products = response.Products
            };

            return View(view);
        }
    }
}
