using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebSite.Configurations;
using WebSite.Models.Requests;
using WebSite.Services.Abstractions;

namespace WebSite.Controllers
{
    public class RelatedProductController : Controller
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly IRelatedProductService _relatedProductService;
        private readonly WebSiteConfig _options;

        public RelatedProductController(
            ILogger<CatalogController> logger,
            IOptions<Config> options,
            IRelatedProductService relatedProductService)
        {
            _logger = logger;
            _options = options.Value.WebSiteConfig;
            _relatedProductService = relatedProductService;
        }

        public async Task<IActionResult> Catalog(int page)
        {
            ViewBag.Page = page;
            ViewBag.PageSize = _options.PageSize;

            var request = new GetByPageRequest() { Page = page, PageSize = _options.PageSize };
            var response = await _relatedProductService.GetByPage(request);
            return View(response);
        }
    }
}
