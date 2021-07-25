using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSite.Services.Abstractions;

namespace WebSite.Controllers
{
    public class GameCatalogController : Controller
    {
        private readonly ILogger<GameCatalogController> _logger;
        private readonly ICatalogService _catalogService;

        public GameCatalogController(ILogger<GameCatalogController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Catalog(int page)
        {
            var response = await _catalogService.GetByPage(page);
            return View(response);
        }
    }
}
