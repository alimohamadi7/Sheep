using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sheep.Core.Application.Category.CategoryPrice;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Framework.Domain.Entities;
using System.Text.RegularExpressions;

namespace Sheep.Endpoint.Mvc.Controllers
{
    public class CategoryPriceController : Controller
    {
        private readonly ICategoryPriceApplication _categoryPriceApplication;
        public CategoryPriceController(ICategoryPriceApplication categoryPriceApplication)
        {
            _categoryPriceApplication = categoryPriceApplication;

        }

        public async Task< IActionResult> Index(CancellationToken cancellationToken,string? start, string? end,CategoryType category,GenderType gender, int PageId=1)
        {
            return View(await _categoryPriceApplication.GetAll(cancellationToken , start,end,category,gender,PageId));
        }
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {

            return PartialView(nameof (Create));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommand Command,CancellationToken cancellationToken)
        {
            var result=await _categoryPriceApplication.Create(Command,cancellationToken);
            return new JsonResult(result);  
        }
        public async Task<IActionResult> Edit(Guid Id, CancellationToken cancellationToken)
        {
            var result = await _categoryPriceApplication.GetDetails(Id, cancellationToken);
            return PartialView (result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCommand Command, CancellationToken cancellationToken)
        {
            var result=await _categoryPriceApplication.Edit(Command, cancellationToken); 
            return new JsonResult (result);
        }
    }
}
