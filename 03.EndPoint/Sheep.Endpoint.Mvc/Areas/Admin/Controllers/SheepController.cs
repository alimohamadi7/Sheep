
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Sheep.Endpoint.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SheepController : Controller
    {


        public SheepController()
        {

        }

        // GET: SheepController
        public async Task< ActionResult> Index( string trim ,int pageId)
        {
            return View();
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
