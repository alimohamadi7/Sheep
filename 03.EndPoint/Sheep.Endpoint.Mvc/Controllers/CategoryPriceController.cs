using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Application.Category.Contracts;
using System.Text.RegularExpressions;

namespace Sheep.Endpoint.Mvc.Controllers
{
    public class CategoryPriceController : Controller
    {
        private readonly ICategoryPriceApplication _categoryPriceApplication;
        private readonly ICategoryApplication _categoryApplication;
        public CategoryPriceController(ICategoryPriceApplication categoryPriceApplication, ICategoryApplication categoryApplication)
        {
            _categoryPriceApplication = categoryPriceApplication;
            _categoryApplication = categoryApplication;
        }

        public async Task< IActionResult> Index(CancellationToken cancellationToken ,int PageId=1, string trim="")
        {
            return View(await _categoryPriceApplication.GetAll(cancellationToken , PageId,trim));
        }
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var result = await _categoryApplication.GetAllCategoryForFood(cancellationToken);
        var Selectlist=  result.Select(x => new SelectListItem 
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            });
            ViewData["Category"] = new SelectList(Selectlist, "Value", "Text");
            return PartialView(nameof (Create));
        }
    }
}
