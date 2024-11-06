
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Sheep.Contracts;


namespace Sheep.Endpoint.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SheepController : Controller
    {

        private readonly ISheepApplication _sheepApplication;

        public SheepController(ISheepApplication sheepApplication)
        {
            _sheepApplication = sheepApplication;
        }

        // GET: SheepController
        public async Task< ActionResult> Index( CancellationToken cancellationToken,string trim ,int pageId)
        {
            return View(await _sheepApplication.GetAllSheep(cancellationToken ,pageId,trim));
        }

        // GET: SheepController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SheepController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SheepController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SheepController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SheepController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SheepController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
