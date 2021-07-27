using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebSite.Common.Enums;
using WebSite.Configurations;
using WebSite.Models;
using WebSite.Models.Requests;
using WebSite.Services.Abstractions;

namespace WebSite.Controllers
{
    public class GameCatalogController : Controller
    {
        private readonly ILogger<GameCatalogController> _logger;
        private readonly IGameService _catalogService;
        private readonly WebSiteConfig _options;

        public GameCatalogController(
            ILogger<GameCatalogController> logger,
            IOptions<Config> options,
            IGameService catalogService)
        {
            _logger = logger;
            _options = options.Value.WebSiteConfig;
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Catalog(int page, SortedTypeEnum sortedType)
        {
            var request = new GetByPageProductRequest() { Page = page, PageSize = _options.PageSize, SortedType = sortedType };
            var response = await _catalogService.GetByPage(request);
            if (response != null)
            {
                var view = new GameCatalogViewModel()
                {
                    Games = response.Games,
                    TotalRecords = response.TotalRecords,
                    CurrentPage = page,
                    PageSize = _options.PageSize,
                    SortedType = sortedType
                };
                return View(view);
            }

            return View("you died!");
        }

        public async Task<IActionResult> GetById(string id, int page, SortedTypeEnum sortedType)
        {
            var request = new GetByIdProductRequest() { Id = id };
            var response = await _catalogService.GetById(request);
            if (response != null)
            {
                var view = new GameViewModel()
                {
                    Game = response.Game,
                    Page = page,
                    SortedType = sortedType
                };
                return View(view);
            }

            return View("you died!");
        }
    }
}
