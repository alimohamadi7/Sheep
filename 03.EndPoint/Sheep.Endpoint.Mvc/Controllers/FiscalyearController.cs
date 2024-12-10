
using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Fiscalyear;
using Sheep.Core.Application.Fiscalyear.Contracts;
using System.Security.AccessControl;

namespace Sheep.Endpoint.Mvc.Controllers
{
    public class FiscalyearController : Controller
    {
        private readonly IFiscalyearApplication _fiscalyearApplication;

        public FiscalyearController(IFiscalyearApplication fiscalyearApplication)
        {
            _fiscalyearApplication = fiscalyearApplication;
        }

        // GET: FiscalyearController
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _fiscalyearApplication.GetAll(cancellationToken));
        }

        // GET: FiscalyearController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FiscalyearController/Create
        public async Task<IActionResult> Create()
        {
            return PartialView(nameof(Create));
        }

        // POST: FiscalyearController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCommand Command, CancellationToken  cancellationToken)
        {
            var result = await _fiscalyearApplication.Create(Command, cancellationToken);
            return new JsonResult(result);
        }

        // GET: FiscalyearController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: FiscalyearController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FiscalyearController/Delete/5
        public async Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            return PartialView(nameof(Delete),await _fiscalyearApplication.GetDetails(id,cancellationToken));
        }

        // POST: FiscalyearController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(Guid id,CancellationToken cancellationToken )
        {
            var result = await _fiscalyearApplication.Delete(id, cancellationToken);
            return new JsonResult(result);
        }
    }
}
