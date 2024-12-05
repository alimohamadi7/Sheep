using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;

namespace Sheep.Endpoint.Mvc.Controllers
{
    public class CategoryPrice : Controller
    {
        private readonly ICategoryPriceRepository _categoryPriceRepository;

        public CategoryPrice(ICategoryPriceRepository categoryPriceRepository)
        {
            _categoryPriceRepository = categoryPriceRepository;
        }

        public async Task< IActionResult> Index(CancellationToken cancellationToken ,int PageId=1, string trim="")
        {
            return View(await _categoryPriceRepository.GetAll(cancellationToken , PageId,trim));
        }
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            return PartialView(nameof (Create));
        }
    }
}
