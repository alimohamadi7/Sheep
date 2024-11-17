
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Sheep.Contracts;


namespace Sheep.Endpoint.Mvc.Controllers
{
    public class SheepController : Controller
    {

        private readonly ISheepApplication _sheepApplication;

        public SheepController(ISheepApplication sheepApplication)
        {
            _sheepApplication = sheepApplication;
        }

        // GET: SheepController
        public async Task<ActionResult> Index(CancellationToken cancellationToken, string trim = "", int pageId = 1)
        {
            return View(await _sheepApplication.GetAllSheep(cancellationToken, pageId, trim));
        }

        // GET: SheepController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SheepController/Create
        public async Task<ActionResult> Create()
        {
            return PartialView(nameof(Create));
        }

        // POST: SheepController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            var result = await _sheepApplication.IsExistSheep(command, cancellationToken);
            if (result.isSuccedded == false)
            {
                ModelState.AddModelError(nameof(command.SheepNumber), result.Message);
            }
            await _sheepApplication.Create(command, cancellationToken);
            return new JsonResult(result);

        }

        // GET: SheepController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: SheepController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
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

        // GET: SheepController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: SheepController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
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
    }
}
