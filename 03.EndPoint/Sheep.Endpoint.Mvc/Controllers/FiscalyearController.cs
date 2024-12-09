
using Microsoft.AspNetCore.Mvc;

namespace Sheep.Endpoint.Mvc.Controllers
{
    public class FiscalyearController : Controller
    {
        // GET: FiscalyearController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FiscalyearController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FiscalyearController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FiscalyearController/Create
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

        // GET: FiscalyearController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FiscalyearController/Edit/5
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

        // GET: FiscalyearController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FiscalyearController/Delete/5
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
