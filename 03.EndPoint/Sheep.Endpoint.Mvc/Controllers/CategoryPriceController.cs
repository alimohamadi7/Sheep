using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Category.CategoryPrice;
using Sheep.Core.Application.Category.CategoryPrice.Contracts;
using Sheep.Framework.Application.Operation;
using Sheep.Framework.Domain.Entities;


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
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryPriceApplication.GetDetails(id, cancellationToken);
            return PartialView(nameof(Delete), result);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfrim(Guid id, CancellationToken cancellationToken)
        {
            var result = await _categoryPriceApplication.Delete(id, cancellationToken);
            return new JsonResult(result);
        }
        public async Task<IActionResult> Calcute(Guid Id, CancellationToken cancellationToken)
        {
            var result = await _categoryPriceApplication.GetDetailsForCalcute(Id, cancellationToken);
            return PartialView(nameof(Calcute),result);
        }
        [HttpPost]
        public async Task<IActionResult> Calcute(CalcuteCommand Command, CancellationToken cancellationToken)
        {
            OperationResult<bool> result=new OperationResult<bool>();
            switch (Command.Category)   
            {
                case CategoryType.none:
                    break;
                case CategoryType.Zero_Three:
                    break;
                case CategoryType.Three_Six:
                    result= await _categoryPriceApplication.CalculatedPriceThreeSix(Command, cancellationToken);
                    break;
                case CategoryType.Six_Eighteen:
                    result=await _categoryPriceApplication.CalculatedPriceSixEighteen(Command, cancellationToken);
                    break;
                case CategoryType.Ewe:
                    break;
                case CategoryType.Ram:
                    break;
                default:
                    break;
            }
            // Thread.Sleep(9000);
            return new JsonResult(result);
        }

    }
}
