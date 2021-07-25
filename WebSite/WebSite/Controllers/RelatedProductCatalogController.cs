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
    public class RelatedProductCatalogController : Controller
    {
        private readonly ILogger<GameCatalogController> _logger;
        private readonly IRelatedProductService _relatedProductService;
        private readonly WebSiteConfig _options;

        public RelatedProductCatalogController(
            ILogger<GameCatalogController> logger,
            IOptions<Config> options,
            IRelatedProductService relatedProductService)
        {
            _logger = logger;
            _options = options.Value.WebSiteConfig;
            _relatedProductService = relatedProductService;
        }

        public async Task<IActionResult> Catalog(int page, SortedTypeEnum sortedType)
        {
            var request = new GetByPageProductRequest() { Page = page, PageSize = _options.PageSize, SortedType = sortedType };
            var response = await _relatedProductService.GetByPage(request);
            if (response != null)
            {
                var view = new RelatedPorductCatalogViewModel()
                {
                    RelatedProducts = response.RelatedProducts,
                    TotalRecords = response.TotalRecords,
                    CurrentPage = page,
                    PageSize = _options.PageSize,
                    SortedType = sortedType
                };
                return View(view);
            }

            return View("you died!");
        }
    }
}
