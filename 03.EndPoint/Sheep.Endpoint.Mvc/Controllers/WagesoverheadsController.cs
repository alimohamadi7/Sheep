using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Wages_overheads;
using Sheep.Core.Application.Wages_overheads.Contracts;

namespace Sheep.Endpoint.Mvc.Controllers
{
    public class WagesoverheadsController : Controller
    {
        private readonly IWagesoverheadsApplication  _wagesoverheadsApplication;

        public WagesoverheadsController(IWagesoverheadsApplication wagesoverheadsApplication)
        {
            _wagesoverheadsApplication = wagesoverheadsApplication;
        }

        // GET: WagesoverheadsController
        public async Task< IActionResult> Index(CancellationToken cancellationToken,string? start ,string end, int PageId = 1)
        {
            return View(await _wagesoverheadsApplication.GetAll(cancellationToken ,start,end,PageId));
        }

        // GET: WagesoverheadsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: WagesoverheadsController/Create
        public async Task<IActionResult> Create()
        {
            return PartialView(nameof(Create));
        }

        // POST: WagesoverheadsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCommand command ,CancellationToken cancellationToken)
        {
            var result = await _wagesoverheadsApplication.Create(command, cancellationToken);
            return new JsonResult(result);
        }

        // GET: WagesoverheadsController/Edit/5
        public async Task<IActionResult> Edit(Guid id ,CancellationToken cancellationToken)
        {
            var result=await _wagesoverheadsApplication.GetDetails(id,cancellationToken);
            return PartialView(nameof(Edit),result);
        }

        // POST: WagesoverheadsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCommand Command,CancellationToken cancellationToken)
        {
            var result = await _wagesoverheadsApplication.Edit(Command, cancellationToken);
            return new JsonResult(result);  
        }

        // GET: WagesoverheadsController/Delete/5
        public async Task<IActionResult> Delete(Guid Id ,CancellationToken cancellationToken)
        {
            var result = await _wagesoverheadsApplication.GetDetails(Id, cancellationToken);
            return PartialView(nameof(Delete), result);
        }

        // POST: WagesoverheadsController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(Guid Id, CancellationToken cancellationToken )
        {
            var result=await _wagesoverheadsApplication.Delete(Id,cancellationToken);
            return new JsonResult(result);
        }
    }
}
